using Npc;
using UnityEngine;
using UnityEngine.UI;
using UtilityAi;
using UtilityAi.Actions;

namespace Ui
{
    public class NpcView : MonoBehaviour
    {
        [SerializeField] private AiBrain _aiBrain;
        [SerializeField] private NpcStats _npcStats;

        [SerializeField] private Text _bestActionText;

        [SerializeField] private Text _energyText;
        [SerializeField] private Text _hungerText;
        [SerializeField] private Text _moneyText;

        private void OnEnable()
        {
            _aiBrain.OnBestActionDecided += UpdateBestActionText;
            _npcStats.OnStatsUpdated += UpdateStats;
        }

        private void OnDisable()
        {
            _aiBrain.OnBestActionDecided -= UpdateBestActionText;
            _npcStats.OnStatsUpdated -= UpdateStats;
        }

        private void Start()
        {
            UpdateStats();
        }

        private void UpdateStats()
        {
            _energyText.text = _npcStats.Energy.ToString();
            _hungerText.text = _npcStats.Hunger.ToString();
            _moneyText.text = _npcStats.Money.ToString();
        }

        private void UpdateBestActionText(IAiAction aiAction)
        {
            _bestActionText.text = aiAction.Name;
        }
    }
}