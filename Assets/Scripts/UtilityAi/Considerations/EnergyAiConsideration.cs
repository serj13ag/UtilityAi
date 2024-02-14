using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class EnergyAiConsideration : AiConsideration
    {
        public EnergyAiConsideration(string name, AnimationCurve responseCurve) : base(name, responseCurve)
        {
        }

        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Energy / 100f;
        }
    }
}