using System;
using System.Collections;
using Controllers.NpcStates;
using Entities;
using Ui;
using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private NpcView _npcView;

        [SerializeField] private MoveController _moveController;
        [SerializeField] private NpcStatsController _statsController;
        [SerializeField] private NpcInventoryController _inventoryController;
        [SerializeField] private AiBrain _aiBrain;

        [SerializeField] private float _workTimeSeconds;
        [SerializeField] private float _sleepTimeSeconds;

        [SerializeField] private AiAction[] _actions;

        private INpcState _state;

        public NpcStatsController Stats => _statsController;

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
            _statsController.UpdateStats(Time.deltaTime);
        }

        public void ChangeState(NpcState state)
        {
            INpcState newState;
            switch (state)
            {
                case NpcState.Deciding:
                    newState = new DecidingNpcState(this, _aiBrain, _actions);
                    break;
                case NpcState.Moving:
                    newState = new MovingNpcState(this, _moveController, _aiBrain.BestAction.DestinationPosition);
                    break;
                case NpcState.Executing:
                    newState = new ExecutingNpcState(this, _aiBrain.BestAction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }

            _state = newState;
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
            _statsController.Hunger -= 20;
            _statsController.Money -= 200;

            DecideNewAction();
        }

        private void AiBrain_OnBestActionDecided()
        {
            _aiBrain.BestAction.Execute(this);

            _npcView.UpdateBestAction(_aiBrain.BestAction);
        }

        private IEnumerator WorkRoutine()
        {
            yield return new WaitForSeconds(_workTimeSeconds);
            _inventoryController.AddResource(ResourceType.Wood, 10);
            _statsController.Money += 100;

            DecideNewAction();
        }

        private IEnumerator SleepRoutine()
        {
            yield return new WaitForSeconds(_sleepTimeSeconds);
            _statsController.Energy += 5;

            DecideNewAction();
        }

        private void DecideNewAction()
        {
            ChangeState(NpcState.Deciding);
        }

        public Vector3 GetSleepPosition()
        {
            return Vector3.zero;
        }

        public Vector3 GetWorkPosition()
        {
            return new Vector3(-5f, 0f, -5f);
        }
    }
}