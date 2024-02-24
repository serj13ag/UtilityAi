using Npc.Interfaces;
using Npc.NpcStates;
using UnityEngine;
using UtilityAi;

namespace Npc
{
    public class DefaultNpc : MonoBehaviour,
        IEater, ISleeper, IWorker,
        IEntityWithHunger, IEntityWithEnergy, IEntityWithMoney
    {
        [SerializeField] private NpcMover _mover;
        [SerializeField] private NpcStats _stats;
        [SerializeField] private NpcInventory _inventory;
        [SerializeField] private AiBrain _aiBrain;

        [SerializeField] private float _workTimeSeconds;
        [SerializeField] private float _sleepTimeSeconds;

        private NpcStateBlock _stateBlock;

        public NpcInventory Inventory => _inventory;
        public NpcStats Stats => _stats;

        public float WorkTimeSeconds => _workTimeSeconds;
        public float SleepTimeSeconds => _sleepTimeSeconds;

        public float HungerNormalized => _stats.HungerNormalized;
        public float EnergyNormalized => _stats.EnergyNormalized;
        public float MoneyNormalized => _stats.MoneyNormalized;

        private void Awake()
        {
            _stateBlock = new NpcStateBlock(this, _aiBrain, _mover);
        }

        private void Start()
        {
            _stateBlock.DecideNewAction();
        }

        private void Update()
        {
            _stateBlock.Update(Time.deltaTime);
        }

        public Vector3 GetSleepPosition()
        {
            return new Vector3(1f, 1f, 1f);
        }

        public Vector3 GetWorkPosition()
        {
            return new Vector3(-5f, 1f, -5f);
        }

        public void DoWork()
        {
            _stateBlock.ChangeState(NpcState.Working);
        }

        public void DoSleep()
        {
            _stateBlock.ChangeState(NpcState.Sleeping);
        }

        public void DoEat()
        {
            _stats.Hunger -= 20;
            _stats.Money -= 200;

            _stateBlock.DecideNewAction();
        }
    }
}