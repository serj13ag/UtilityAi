using Controllers;
using UnityEngine;

namespace UtilityAi.Actions
{
    [CreateAssetMenu(fileName = "Work", menuName = "UtilityAi/Actions/Work")]
    public class WorkAiAction : AiAction
    {
        public override void Execute(NpcController npcController)
        {
            npcController.DoWork();
        }
    }
}