using UtilityAi.Actions;

namespace Controllers.NpcStates
{
    public class ExecutingNpcState : INpcState
    {
        private readonly IAiAction _action;

        public ExecutingNpcState(IAiAction action)
        {
            _action = action;
        }

        public void Update(float deltaTime)
        {
            _action.Execute();
        }
    }
}