using Controllers;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class WorkAiAction : AiAction, IAiActionWithDestination
    {
        public Vector3 DestinationPosition { get; private set; }

        public WorkAiAction(string name, AiConsideration[] considerations) : base(name, considerations)
        {
        }

        public override void Execute(NpcController npcController)
        {
            npcController.DoWork();
        }

        public void SetDestinationPosition(NpcController npcController)
        {
            DestinationPosition = npcController.GetWorkPosition();
        }
    }
}