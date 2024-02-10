using Controllers;
using UnityEngine;

namespace UtilityAi.Actions
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAi/Actions/Sleep")]
    public class SleepAiAction : AiAction
    {
        public override void Execute(NpcController npcController)
        {
            npcController.DoSleep();
        }
    }
}