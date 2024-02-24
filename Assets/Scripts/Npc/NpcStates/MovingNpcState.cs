using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Npc.NpcStates
{
    public class MovingNpcState : INpcState
    {
        private readonly DefaultNpc _npc;
        private readonly Vector3 _destinationPosition;

        public MovingNpcState(DefaultNpc npc, NpcMover npcMover, Vector3? destinationPosition)
        {
            Debug.Assert(destinationPosition != null, nameof(destinationPosition) + " != null");

            _npc = npc;
            _destinationPosition = destinationPosition.Value;

            npcMover.MoveTo(destinationPosition.Value);
        }

        public void Update(float deltaTime)
        {
            if (Vector3.Distance(_destinationPosition, _npc.transform.position) < 1f)
            {
                _npc.ChangeState(NpcState.Executing);
            }
        }
    }
}