using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Npc
{
    public class NpcInventory : MonoBehaviour
    {
        [SerializeField] private int _maxTotalCapacity;

        private Dictionary<ResourceType, int> _inventory;
        private int _currentAmount;

        private void Start()
        {
            _inventory = new Dictionary<ResourceType, int>()
            {
                { ResourceType.Water, 0 },
                { ResourceType.Stone, 0 },
                { ResourceType.Wood, 0 },
            };
        }

        public void AddResource(ResourceType resourceType, int amount)
        {
            if (_currentAmount >= _maxTotalCapacity)
            {
                return;
            }

            var freeCapacity = _maxTotalCapacity - _currentAmount;
            var amountToAdd = Math.Min(_currentAmount + amount, freeCapacity);

            _currentAmount += amountToAdd;
            _inventory[resourceType] += amountToAdd;
        }
    }
}