using UnityEngine;
using UtilityAi.Actions;

namespace Npc.NpcStates
{
    public class MovingToActionDestinationNpcState : INpcState
    {
        private readonly DefaultNpc _npc;
        private readonly IAiActionWithDestination _actionWithDestination;

        public MovingToActionDestinationNpcState(DefaultNpc npc, NpcMover npcMover,
            IAiActionWithDestination actionWithDestination)
        {
            _npc = npc;
            _actionWithDestination = actionWithDestination;

            npcMover.MoveTo(_actionWithDestination.DestinationPosition);
        }

        public void Update(float deltaTime)
        {
            _npc.Stats.TickEnergy(deltaTime);
            _npc.Stats.TickHunger(deltaTime);

            if (Vector3.Distance(_actionWithDestination.DestinationPosition, _npc.transform.position) < 1f)
            {
                _actionWithDestination.Execute();
            }
        }
    }
}