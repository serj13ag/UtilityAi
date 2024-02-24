using Npc.Interfaces;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class HungerAiConsideration : AiConsideration
    {
        private readonly IEntityWithHunger _entityWithHunger;

        public HungerAiConsideration(string name, AnimationCurve responseCurve, IEntityWithHunger entityWithHunger)
            : base(name, responseCurve)
        {
            _entityWithHunger = entityWithHunger;
        }

        protected override float GetNormalizedValue()
        {
            return _entityWithHunger.HungerNormalized;
        }
    }
}