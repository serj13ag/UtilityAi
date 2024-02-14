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

        private float ScoreAction(AiAction action)
        {
            var score = 1f;

            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration(_npcController);
                score *= considerationScore;

                if (score == 0)
                {
                    action.Score = 0;
                    return action.Score;
                }
            }

            var originalScore = score;
            var modFactor = 1 - 1 / action.Considerations.Length;
            var makeUpValue = (1 - originalScore) * modFactor;

            action.Score = originalScore + makeUpValue * originalScore;

            return action.Score;
        }

        public void DecideBestAction()
        {
            var bestScore = 0f;
            var bestActionIndex = 0;
            for (var i = 0; i < _actions.Length; i++)
            {
                if (ScoreAction(_actions[i]) > bestScore)
                {
                    bestScore = _actions[i].Score;
                    bestActionIndex = i;
                }
            }

            BestAction = _actions[bestActionIndex];
            BestAction.SetDestinationPosition(_npcController);
        }
    }
}