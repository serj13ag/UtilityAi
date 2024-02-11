using System.Collections;
using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private NpcStatsController _statsController;
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
            Debug.Log("Eat action ended");

            DecideNewAction();
        }

        private void AiBrain_OnBestActionDecided()
        {
            _aiBrain.BestAction.Execute(this);
        }

        private IEnumerator WorkRoutine()
        {
            Debug.Log("Work action started");
            yield return new WaitForSeconds(_workTimeSeconds);
            Debug.Log("Work action ended");

            DecideNewAction();
        }

        private IEnumerator SleepRoutine()
        {
            Debug.Log("Sleep action started");
            yield return new WaitForSeconds(_sleepTimeSeconds);
            Debug.Log("Sleep action ended");

            DecideNewAction();
        }

        private void DecideNewAction()
        {
            _aiBrain.DecideBestAction(_actions);
        }
    }
}