using UnityEngine;

namespace Entities
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType;
        [Min(1)] [SerializeField] private int _initialAmount;

        private int _amountAvailable;

        public ResourceType ResourceType => _resourceType;

        private void Start()
        {
            _amountAvailable = _initialAmount;
        }

        public void Gather(int amountToGather)
        {
            if (amountToGather > _amountAvailable)
            {
                amountToGather = _amountAvailable;
            }

            _amountAvailable -= amountToGather;

            if (_amountAvailable == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}