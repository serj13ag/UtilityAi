using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Controllers
{
    public class NpcInventoryController : MonoBehaviour
    {
        [SerializeField] private int _maxCapacityPerResource;

        private Dictionary<ResourceType, int> _inventory;

        private void Start()
        {
            _inventory = new Dictionary<ResourceType, int>()
            {
                { ResourceType.Food, 0 },
                { ResourceType.Stone, 0 },
                { ResourceType.Wood, 0 },
            };
        }

        public void AddResource(ResourceType resourceType, int amount)
        {
            var currentAmount = _inventory[resourceType];

            _inventory[resourceType] = Math.Max(currentAmount + amount, _maxCapacityPerResource);
        }
    }
}