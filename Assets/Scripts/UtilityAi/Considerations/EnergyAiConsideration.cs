using Controllers.Interfaces;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class EnergyAiConsideration : AiConsideration
    {
        private readonly IEntityWithEnergy _entityWithEnergy;

        public EnergyAiConsideration(string name, AnimationCurve responseCurve, IEntityWithEnergy entityWithEnergy)
            : base(name, responseCurve)
        {
            _entityWithEnergy = entityWithEnergy;
        }

        protected override float GetNormalizedValue()
        {
            return _entityWithEnergy.EnergyNormalized;
        }
    }
}