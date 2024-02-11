using System;
using UnityEngine;

namespace Controllers
{
    public class NpcStatsController : MonoBehaviour
    {
        [SerializeField] private float _decreaseEnergyTimeout;
        [SerializeField] private float _increaseHungerTimeout;

        private float _timeTillDecreaseEnergy;
        private float _timeTillIncreaseHunger;

        private int _energy;
        private int _hunger;
        private int _money;

        private int Energy
        {
            get => _energy;
            set => _energy = Math.Clamp(value, 0, 100);
        }

        private int Hunger
        {
            get => _hunger;
            set => _hunger = Math.Clamp(value, 0, 100);
        }

        private int Money
        {
            get => _money;
            set => _money = Math.Clamp(value, 0, 100);
        }

        private void Start()
        {
            _energy = 100;
            _hunger = 0;
            _money = 50;

            _timeTillDecreaseEnergy = _decreaseEnergyTimeout;
            _timeTillIncreaseHunger = _increaseHungerTimeout;
        }

        public void UpdateStats(float deltaTime)
        {
            UpdateEnergy(deltaTime);
            UpdateHunger(deltaTime);
        }

        private void UpdateHunger(float deltaTime)
        {
            _timeTillIncreaseHunger -= deltaTime;
            if (_timeTillIncreaseHunger < 0)
            {
                Hunger++;
                _timeTillIncreaseHunger = _increaseHungerTimeout;
            }
        }

        private void UpdateEnergy(float deltaTime)
        {
            _timeTillDecreaseEnergy -= deltaTime;
            if (_timeTillDecreaseEnergy < 0)
            {
                Energy--;
                _timeTillDecreaseEnergy = _decreaseEnergyTimeout;
            }
        }
    }
}