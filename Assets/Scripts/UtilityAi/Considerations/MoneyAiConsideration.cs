using Npc.Interfaces;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public class MoneyAiConsideration : AiConsideration
    {
        private readonly IEntityWithMoney _entityWithMoney;

        public MoneyAiConsideration(string name, AnimationCurve responseCurve, IEntityWithMoney entityWithMoney)
            : base(name, responseCurve)
        {
            _entityWithMoney = entityWithMoney;
        }

        protected override float GetNormalizedValue()
        {
            return _entityWithMoney.MoneyNormalized;
        }
    }
}