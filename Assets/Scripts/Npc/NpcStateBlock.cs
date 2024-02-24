using System;
using Npc.NpcStates;
using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Npc
{
    public class NpcStateBlock
    {
        private readonly DefaultNpc _defaultNpc;
        private readonly AiBrain _aiBrain;
        private readonly NpcMover _mover;

        private INpcState _state;

        public NpcStateBlock(DefaultNpc defaultNpc, AiBrain aiBrain, NpcMover mover)
        {
            _defaultNpc = defaultNpc;
            _aiBrain = aiBrain;
            _mover = mover;
        }

        public void Update(float deltaTime)
        {
            _state.Update(deltaTime);
        }

        public void ChangeState(NpcState state, IAiAction bestAction = null)
        {
            INpcState newState = state switch
            {
                NpcState.MovingToActionDestination => new MovingToActionDestinationNpcState(_defaultNpc, _mover, bestAction as IAiActionWithDestination),
                NpcState.Working => new WorkingNpcState(this, _defaultNpc, _defaultNpc.WorkTimeSeconds),
                NpcState.Sleeping => new SleepingNpcState(this, _defaultNpc, _defaultNpc.SleepTimeSeconds),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null),
            };

            _state = newState;
        }

        public void DecideNewAction()
        {
            var bestAction = _aiBrain.UpdateBestAction();

            if (NeedMove(bestAction))
            {
                ChangeState(NpcState.MovingToActionDestination, bestAction);
            }
            else
            {
                bestAction.Execute();
            }
        }

        private bool NeedMove(IAiAction action)
        {
            return action is IAiActionWithDestination actionWithDestination
                   && Vector3.Distance(actionWithDestination.DestinationPosition, _defaultNpc.transform.position) > 1f;
        }
    }
}