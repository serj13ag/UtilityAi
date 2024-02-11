using System.Collections;
using Entities;
using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private NpcStatsController _statsController;
        [SerializeField] private NpcInventoryController _inventoryController;
        [SerializeField] private AiBrain _aiBrain;

        [SerializeField] private float _workTimeSeconds;
        [SerializeField] private float _sleepTimeSeconds;

        [SerializeField] private AiAction[] _actions;

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
            _aiBrain.DecideBestAction(_actions);
        }

        private void Update()
        {
            _statsController.UpdateStats(Time.deltaTime);
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
            _statsController.Hunger -= 30;
            _statsController.Money -= 10;

            DecideNewAction();
        }

        private void AiBrain_OnBestActionDecided()
        {
            _aiBrain.BestAction.Execute(this);
        }

        private IEnumerator WorkRoutine()
        {
            yield return new WaitForSeconds(_workTimeSeconds);
            _inventoryController.AddResource(ResourceType.Wood, 10);

            DecideNewAction();
        }

        private IEnumerator SleepRoutine()
        {
            yield return new WaitForSeconds(_sleepTimeSeconds);
            _statsController.Energy++;

            DecideNewAction();
        }

        private void DecideNewAction()
        {
            _aiBrain.DecideBestAction(_actions);
        }
    }
}