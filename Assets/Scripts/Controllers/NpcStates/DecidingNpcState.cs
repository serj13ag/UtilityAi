using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers.NpcStates
{
    public class DecidingNpcState : INpcState
    {
        private readonly NpcController _npcController;
        private readonly AiBrain _aiBrain;
        private readonly AiAction[] _actions;

        public DecidingNpcState(NpcController npcController, AiBrain aiBrain, AiAction[] actions)
        {
            _npcController = npcController;
            _aiBrain = aiBrain;
            _actions = actions;
        }

        public void Update(float deltaTime)
        {
            _aiBrain.DecideBestAction(_actions);

            if (_aiBrain.BestAction.DestinationPosition.HasValue
                && Vector3.Distance(_aiBrain.BestAction.DestinationPosition.Value, _npcController.transform.position) > 1f)
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