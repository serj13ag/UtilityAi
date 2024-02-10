using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Hunger", menuName = "UtilityAi/Considerations/Hunger")]
    public class HungerAiConsideration : AiConsideration
    {
        public override float ScoreConsideration()
        {
            return 0.2f;
        }
    }
}