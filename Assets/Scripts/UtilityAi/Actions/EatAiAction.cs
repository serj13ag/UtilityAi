using Controllers.Interfaces;
using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public class EatAiAction : AiAction
    {
        private readonly IEater _eater;

        public EatAiAction(string name, AiConsideration[] considerations, IEater eater)
            : base(name, considerations)
        {
            _eater = eater;
        }

        public override void Execute()
        {
            _eater.DoEat();
        }
    }
}