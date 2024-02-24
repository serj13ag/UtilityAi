using UnityEngine;
using UnityEngine.AI;

namespace Npc
{
    public class NpcMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.destination = position;
        }
    }
}