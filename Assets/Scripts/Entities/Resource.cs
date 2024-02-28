using UnityEngine;

namespace Entities
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType;

        public ResourceType ResourceType => _resourceType;
    }
}