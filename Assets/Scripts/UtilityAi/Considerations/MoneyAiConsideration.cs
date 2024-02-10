using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Money", menuName = "UtilityAi/Considerations/Money")]
    public class MoneyAiConsideration : AiConsideration
    {
        public override float ScoreConsideration()
        {
            return 0.8f;
        }
    }
}