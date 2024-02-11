using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Hunger", menuName = "UtilityAi/Considerations/Hunger")]
    public class HungerAiConsideration : AiConsideration
    {
        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Hunger / 100f;
        }
    }
}