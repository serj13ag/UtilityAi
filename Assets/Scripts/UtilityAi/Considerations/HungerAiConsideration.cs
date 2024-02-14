using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class HungerAiConsideration : AiConsideration
    {
        public HungerAiConsideration(string name, AnimationCurve responseCurve) : base(name, responseCurve)
        {
        }

        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Hunger / 100f;
        }
    }
}