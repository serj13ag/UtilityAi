using Controllers;
using UnityEngine;

namespace UtilityAi.Considerations
{
    [CreateAssetMenu(fileName = "Energy", menuName = "UtilityAi/Considerations/Energy")]
    public class EnergyAiConsideration : AiConsideration
    {
        protected override float GetValue(NpcController npcController)
        {
            return npcController.Stats.Energy / 100f;
        }
    }
}