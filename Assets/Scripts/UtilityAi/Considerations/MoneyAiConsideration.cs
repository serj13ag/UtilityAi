using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class MoneyAiConsideration : AiConsideration
    {
        public MoneyAiConsideration(string name, AnimationCurve responseCurve) : base(name, responseCurve)
        {
        }

        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Money / 1000f;
        }
    }
}