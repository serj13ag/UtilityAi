using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Npc.NpcStates
{
    public class DecidingNpcState : INpcState
    {
        private readonly DefaultNpc _npc;
        private readonly AiBrain _aiBrain;

        public DecidingNpcState(DefaultNpc npc, AiBrain aiBrain)
        {
            _npc = npc;
            _aiBrain = aiBrain;
        }

        public void Update(float deltaTime)
        {
            _aiBrain.UpdateBestAction();

            if (_aiBrain.BestAction is IAiActionWithDestination actionWithDestination
                && Vector3.Distance(actionWithDestination.DestinationPosition, _npc.transform.position) > 1f)
            {
                _npc.ChangeState(NpcState.Moving);
            }
            else
            {
                _npc.ChangeState(NpcState.Executing);
            }
        }
    }
}