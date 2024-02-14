using UtilityAi.Actions;

namespace Controllers.NpcStates
{
    public class ExecutingNpcState : INpcState
    {
        private readonly NpcController _npcController;
        private readonly AiAction _action;

        public ExecutingNpcState(NpcController npcController, AiAction action)
        {
            _npcController = npcController;
            _action = action;
        }

        public void Update(float deltaTime)
        {
            _action.Execute(_npcController);
        }
    }
}