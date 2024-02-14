using Controllers;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class WorkAiAction : AiAction
    {
        public WorkAiAction(string name, AiConsideration[] considerations) : base(name, considerations)
        {
        }

        public override void Execute(NpcController npcController)
        {
            npcController.DoWork();
        }

        public override void SetDestinationPosition(NpcController npcController)
        {
            DestinationPosition = npcController.GetWorkPosition();
        }
    }
}