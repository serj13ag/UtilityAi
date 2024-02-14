using System;
using Controllers;
using UnityEngine;
using UtilityAi.Actions;

namespace UtilityAi
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] private NpcController _npcController;
        [SerializeField] private AiAction[] _actions;

        private AiAction _bestAction;

        public AiAction BestAction
        {
            get => _bestAction;
            private set
            {
                _bestAction = value;
                OnBestActionDecided?.Invoke();
            }
        }

        public event Action OnBestActionDecided;

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
            BestAction.SetDestinationPosition(_npcController);
        }

        private float CalculateScore(AiAction action)
        {
            var score = 1f;

            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration(_npcController);
                score *= considerationScore;

                if (score == 0)
                {
                    return score;
                }
            }

            var originalScore = score;
            var modFactor = 1 - 1 / action.Considerations.Length;
            var makeUpValue = (1 - originalScore) * modFactor;

            score = originalScore + makeUpValue * originalScore;

            return score;
        }
    }
}