using Controllers;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class SleepAiAction : AiAction
    {
        public SleepAiAction(string name, AiConsideration[] considerations) : base(name, considerations)
        {
        }

        public override void Execute(NpcController npcController)
        {
            npcController.DoSleep();
        }

        public override void SetDestinationPosition(NpcController npcController)
        {
            DestinationPosition = npcController.GetSleepPosition();
        }
    }
}