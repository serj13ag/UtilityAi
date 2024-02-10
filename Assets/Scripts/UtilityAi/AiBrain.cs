using Controllers;
using UnityEngine;
using UtilityAi.Actions;

namespace UtilityAi
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] private NpcController _npcController;

        private AiAction _bestAction;

        public float ScoreAction(AiAction action)
        {
            var score = 1f;

            foreach (var consideration in action.Considerations)
            {
                var considerationScore = consideration.ScoreConsideration();
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

        public void DecideBestAction(AiAction[] actions)
        {
            var bestScore = 0f;
            var bestActionIndex = 0;
            for (var i = 0; i < actions.Length; i++)
            {
                if (ScoreAction(actions[i]) > bestScore)
                {
                    bestScore = actions[i].Score;
                    bestActionIndex = i;
                }
            }

            _bestAction = actions[bestActionIndex];
        }
    }
}