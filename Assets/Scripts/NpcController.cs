using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private MoveController _moveController;
    [SerializeField] private AiBrain _aiBrain;

    private AiAction[] _actions;
}