using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public abstract class AiAction : ScriptableObject
    {
        public string Name;
        public float Score;

        public AiConsideration[] Considerations;

        public abstract void Execute();
    }
}