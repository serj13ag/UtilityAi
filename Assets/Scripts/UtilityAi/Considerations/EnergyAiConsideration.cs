using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Energy", menuName = "UtilityAi/Considerations/Energy")]
    public class EnergyAiConsideration : AiConsideration
    {
        public override float ScoreConsideration()
        {
            return 0.1f;
        }
    }
}