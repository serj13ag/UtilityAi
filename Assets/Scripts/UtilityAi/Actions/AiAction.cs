using Controllers;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public abstract class AiAction
    {
        public string Name { get; }
        public AiConsideration[] Considerations { get; }

        public Vector3? DestinationPosition { get; protected set; }

        protected AiAction(string name, AiConsideration[] considerations)
        {
            Name = name;
            Considerations = considerations;
        }

        public abstract void Execute(NpcController npcController);
        public abstract void SetDestinationPosition(NpcController npcController);
    }
}