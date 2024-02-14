using Controllers;
using UnityEngine;
using UnityEngine.UI;
using UtilityAi.Actions;

namespace Ui
{
    public class NpcView : MonoBehaviour
    {
        [SerializeField] private Text _bestActionText;

        [SerializeField] private Text _energyText;
        [SerializeField] private Text _hungerText;
        [SerializeField] private Text _moneyText;

        public void UpdateStats(NpcStatsController npcStatsController)
        {
            _energyText.text = npcStatsController.Energy.ToString();
            _hungerText.text = npcStatsController.Hunger.ToString();
            _moneyText.text = npcStatsController.Money.ToString();
        }

        public void UpdateBestAction(IAiAction action)
        {
            _bestActionText.text = action.Name;
        }
    }
}