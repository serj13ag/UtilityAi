using UnityEngine;
using UnityEngine.AI;

namespace Controllers
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.destination = position;
        }
    }
}