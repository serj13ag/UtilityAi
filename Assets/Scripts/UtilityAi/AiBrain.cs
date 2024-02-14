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
            _actions = AiActionFactory.CreateActions(_actionsData);
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
                actionWithDestination.SetDestinationPosition(_npcController);
            }
        }

        private float CalculateScore(IAiAction action)
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