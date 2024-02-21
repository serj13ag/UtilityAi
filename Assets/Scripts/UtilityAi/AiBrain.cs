using System;
using Controllers;
using UnityEngine;
using UtilityAi.Actions;
using UtilityAi.Data;

namespace UtilityAi
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] private NpcController _npcController;
        [SerializeField] private AiActionData[] _actionsData;

        private IAiAction[] _actions;
        private IAiAction _bestAction;

        public IAiAction BestAction
        {
            get => _bestAction;
            private set
            {
                _bestAction = value;
                OnBestActionDecided?.Invoke();
            }
        }

        public event Action OnBestActionDecided;

        private void Awake()
        {
            _actions = AiActionFactory.CreateActions(_actionsData, _npcController);
        }

        public void UpdateBestAction()
        {
            var bestScore = 0f;
            var bestActionIndex = 0;
            for (var i = 0; i < _actions.Length; i++)
            {
                var score = CalculateScore(_actions[i]);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestActionIndex = i;
                }
            }

            BestAction = _actions[bestActionIndex];

            if (BestAction is IAiActionWithDestination actionWithDestination)
            {
                actionWithDestination.SetDestinationPosition();
            }
        }

        private float CalculateScore(IAiAction action)
        {
            var actionScore = 1f;
            var modFactor = 1 - 1f / action.Considerations.Length;

            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration(_npcController);

                var makeUpValue = (1 - considerationScore) * modFactor;
                var finalConsiderationScore = considerationScore + makeUpValue * considerationScore;

                actionScore *= finalConsiderationScore;

                if (actionScore == 0)
                {
                    return actionScore;
                }
            }

            return actionScore;
        }
    }
}