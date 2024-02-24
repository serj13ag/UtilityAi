using Entities;

namespace Npc.NpcStates
{
    public class WorkingNpcState : INpcState
    {
        private readonly NpcStateBlock _npcStateBlock;
        private readonly DefaultNpc _defaultNpc;
        private float _secondsTillEndWork;

        public WorkingNpcState(NpcStateBlock npcStateBlock, DefaultNpc defaultNpc, float workTimeSeconds)
        {
            _npcStateBlock = npcStateBlock;
            _defaultNpc = defaultNpc;
            _secondsTillEndWork = workTimeSeconds;
        }

        public void Update(float deltaTime)
        {
            _secondsTillEndWork -= deltaTime;

            _defaultNpc.Stats.TickEnergy(deltaTime);
            _defaultNpc.Stats.TickHunger(deltaTime);

            if (_secondsTillEndWork < 0f)
            {
                _defaultNpc.Inventory.AddResource(ResourceType.Wood, 10);
                _defaultNpc.Stats.Money += 100;

                _npcStateBlock.DecideNewAction();
            }
        }
    }
}