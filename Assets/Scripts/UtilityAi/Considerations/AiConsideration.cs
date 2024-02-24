using System;
using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public abstract class AiConsideration
    {
        private readonly AnimationCurve _responseCurve;

        public string Name { get; }

        protected AiConsideration(string name, AnimationCurve responseCurve)
        {
            Name = name;
            _responseCurve = responseCurve;
        }

        public float ScoreConsideration()
        {
            var value = GetNormalizedValue();
            return _responseCurve.Evaluate(value);
        }

        protected abstract float GetNormalizedValue();
    }
}