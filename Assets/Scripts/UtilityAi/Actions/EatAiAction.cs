using Controllers;
using UnityEngine;

namespace UtilityAi.Actions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAi/Actions/Eat")]
    public class EatAiAction : AiAction
    {
        public override void Execute(NpcController npcController)
        {
            npcController.DoEat();
        }
    }
}