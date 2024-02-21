using UtilityAi.Considerations;

namespace UtilityAi.Actions
{
    public interface IAiAction
    {
        string Name { get; }
        AiConsideration[] Considerations { get; }

        void Execute();
    }
}