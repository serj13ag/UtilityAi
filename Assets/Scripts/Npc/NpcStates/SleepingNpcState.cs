namespace Npc.NpcStates
{
    public class SleepingNpcState : INpcState
    {
        private readonly NpcStateBlock _npcStateBlock;
        private readonly DefaultNpc _defaultNpc;
        private float _secondsTillEndSleeping;

        public SleepingNpcState(NpcStateBlock npcStateBlock, DefaultNpc defaultNpc, float sleepingTimeSeconds)
        {
            _npcStateBlock = npcStateBlock;
            _defaultNpc = defaultNpc;
            _secondsTillEndSleeping = sleepingTimeSeconds;
        }

        public void Update(float deltaTime)
        {
            _secondsTillEndSleeping -= deltaTime;

            _defaultNpc.Stats.TickHunger(deltaTime);
            
            if (_secondsTillEndSleeping < 0f)
            {
                _defaultNpc.Stats.Energy += 5;

                _npcStateBlock.DecideNewAction();
            }
        }
    }
}