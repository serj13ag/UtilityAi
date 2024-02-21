using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public abstract class AiAction : IAiAction
    {
        public string Name { get; }
        public AiConsideration[] Considerations { get; }

        protected AiAction(string name, AiConsideration[] considerations)
        {
            Name = name;
            Considerations = considerations;
        }

        public abstract void Execute();
    }
}