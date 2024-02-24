using System;
using Npc;
using UnityEngine;
using UtilityAi.Actions;
using UtilityAi.Data;

namespace UtilityAi
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] private DefaultNpc _npc;
        [SerializeField] private AiActionData[] _actionsData;

        private IAiAction[] _actions;
        private IAiAction _bestAction;

        public event Action<IAiAction> OnBestActionDecided;

        private void Awake()
        {
            _actions = AiActionFactory.CreateActions(_actionsData, _npc);
        }

        public IAiAction UpdateBestAction()
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

            var bestAction = _actions[bestActionIndex];

            if (bestAction is IAiActionWithDestination actionWithDestination)
            {
                actionWithDestination.SetDestinationPosition();
            }

            _bestAction = bestAction;

            OnBestActionDecided?.Invoke(bestAction);

            return bestAction;
        }

        private static float CalculateScore(IAiAction action)
        {
            var actionScore = 1f;
            var modFactor = 1 - 1f / action.Considerations.Length;

            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration();

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