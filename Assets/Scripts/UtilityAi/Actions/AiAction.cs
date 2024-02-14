using Controllers;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public abstract class AiAction : ScriptableObject
    {
        public string Name;
        public AiConsideration[] Considerations;

        public Vector3? DestinationPosition { get; protected set; }

        public abstract void Execute(NpcController npcController);
        public abstract void SetDestinationPosition(NpcController npcController);
    }
}