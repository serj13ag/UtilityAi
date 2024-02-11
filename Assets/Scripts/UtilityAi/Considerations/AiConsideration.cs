using System;
using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    public abstract class AiConsideration : ScriptableObject
    {
        [SerializeField] private AnimationCurve _responseCurve;

        public string Name;

        public float ScoreConsideration(NpcController npcController)
        {
            var clampedValue = Math.Clamp(GetValue(npcController), 0f, 1f);
            return _responseCurve.Evaluate(clampedValue);
        }

        protected abstract float GetValue(NpcController npcController);
    }
}