using Npc;
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

        public void UpdateStats(NpcStats npcStats)
        {
            _energyText.text = npcStats.Energy.ToString();
            _hungerText.text = npcStats.Hunger.ToString();
            _moneyText.text = npcStats.Money.ToString();
        }

        public void UpdateBestAction(IAiAction action)
        {
            _bestActionText.text = action.Name;
        }
    }
}