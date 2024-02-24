using System;
using System.Collections;
using Entities;
using Npc.Interfaces;
using Npc.NpcStates;
using Ui;
using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Npc
{
    public class DefaultNpc : MonoBehaviour,
        IEater, ISleeper, IWorker,
        IEntityWithHunger, IEntityWithEnergy, IEntityWithMoney
    {
        [SerializeField] private NpcView _npcView;

        [SerializeField] private NpcMover _mover;
        [SerializeField] private NpcStats _stats;
        [SerializeField] private NpcInventory _inventory;
        [SerializeField] private AiBrain _aiBrain;

        [SerializeField] private float _workTimeSeconds;
        [SerializeField] private float _sleepTimeSeconds;

        private INpcState _state;

        public float HungerNormalized => _stats.HungerNormalized;
        public float EnergyNormalized => _stats.EnergyNormalized;
        public float MoneyNormalized => _stats.MoneyNormalized;

        private void OnEnable()
        {
            _aiBrain.OnBestActionDecided += AiBrain_OnBestActionDecided;
        }

        private void OnDisable()
        {
            _aiBrain.OnBestActionDecided -= AiBrain_OnBestActionDecided;
        }

        private void Start()
        {
            ChangeState(NpcState.Deciding);
        }

        private void Update()
        {
            _state.Update(Time.deltaTime);
            _stats.UpdateStats(Time.deltaTime);
        }

        public void ChangeState(NpcState state)
        {
            INpcState newState;
            switch (state)
            {
                case NpcState.Deciding:
                    newState = new DecidingNpcState(this, _aiBrain);
                    break;
                case NpcState.Moving:
                    newState = new MovingNpcState(this, _mover, ((IAiActionWithDestination)_aiBrain.BestAction).DestinationPosition);
                    break;
                case NpcState.Executing:
                    newState = new ExecutingNpcState(_aiBrain.BestAction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }

            _state = newState;
        }

        public Vector3 GetSleepPosition()
        {
            return Vector3.zero;
        }

        public Vector3 GetWorkPosition()
        {
            return new Vector3(-5f, 0f, -5f);
        }

        public void DoWork()
        {
            StartCoroutine(WorkRoutine());
        }

        public void DoSleep()
        {
            StartCoroutine(SleepRoutine());
        }

        public void DoEat()
        {
            _stats.Hunger -= 20;
            _stats.Money -= 200;

            DecideNewAction();
        }

        private void AiBrain_OnBestActionDecided()
        {
            _aiBrain.BestAction.Execute();

            _npcView.UpdateBestAction(_aiBrain.BestAction);
        }

        private IEnumerator WorkRoutine()
        {
            yield return new WaitForSeconds(_workTimeSeconds);
            _inventory.AddResource(ResourceType.Wood, 10);
            _stats.Money += 100;

            DecideNewAction();
        }

        private IEnumerator SleepRoutine()
        {
            yield return new WaitForSeconds(_sleepTimeSeconds);
            _stats.Energy += 5;

            DecideNewAction();
        }

        private void DecideNewAction()
        {
            ChangeState(NpcState.Deciding);
        }
    }
}