using Controllers;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class EatAiAction : AiAction
    {
        public EatAiAction(string name, AiConsideration[] considerations) : base(name, considerations)
        {
        }

        public override void Execute(NpcController npcController)
        {
            npcController.DoEat();
        }

        public override void SetDestinationPosition(NpcController npcController)
        {
        }
    }
}