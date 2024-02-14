using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers.NpcStates
{
    public class DecidingNpcState : INpcState
    {
        private readonly NpcController _npcController;
        private readonly AiBrain _aiBrain;

        public DecidingNpcState(NpcController npcController, AiBrain aiBrain)
        {
            _npcController = npcController;
            _aiBrain = aiBrain;
        }

        public void Update(float deltaTime)
        {
            _aiBrain.UpdateBestAction();

            if (_aiBrain.BestAction is IAiActionWithDestination actionWithDestination
                && Vector3.Distance(actionWithDestination.DestinationPosition, _npcController.transform.position) > 1f)
            {
                _npcController.ChangeState(NpcState.Moving);
            }
            else
            {
                _npcController.ChangeState(NpcState.Executing);
            }
        }
    }
}