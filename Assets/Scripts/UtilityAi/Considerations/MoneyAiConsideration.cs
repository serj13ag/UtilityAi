using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Money", menuName = "UtilityAi/Considerations/Money")]
    public class MoneyAiConsideration : AiConsideration
    {
        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Money / 1000f;
        }
    }
}