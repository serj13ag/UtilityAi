using UnityEngine;
using UtilityAi;
using UtilityAi.Actions;

namespace Controllers
{
    public class NpcController : MonoBehaviour
    {
        [SerializeField] private MoveController _moveController;
        [SerializeField] private AiBrain _aiBrain;

        private AiAction[] _actions;
    }
}