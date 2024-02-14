using Controllers;
using UnityEngine;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class SleepAiAction : AiAction, IAiActionWithDestination
    {
        public Vector3 DestinationPosition { get; private set; }

        public SleepAiAction(string name, AiConsideration[] considerations) : base(name, considerations)
        {
        }

        public override void Execute(NpcController npcController)
        {
            npcController.DoSleep();
        }

        public void SetDestinationPosition(NpcController npcController)
        {
            DestinationPosition = npcController.GetSleepPosition();
        }
    }
}