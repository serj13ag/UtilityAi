using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Controllers.NpcStates
{
    public class MovingNpcState : INpcState
    {
        private readonly NpcController _npcController;
        private readonly Vector3 _destinationPosition;

        public MovingNpcState(NpcController npcController, MoveController moveController, Vector3? destinationPosition)
        {
            Debug.Assert(destinationPosition != null, nameof(destinationPosition) + " != null");

            _npcController = npcController;
            _destinationPosition = destinationPosition.Value;

            moveController.MoveTo(destinationPosition.Value);
        }

        public void Update(float deltaTime)
        {
            if (Vector3.Distance(_destinationPosition, _npcController.transform.position) < 1f)
            {
                _npcController.ChangeState(NpcState.Executing);
            }
        }
    }
}