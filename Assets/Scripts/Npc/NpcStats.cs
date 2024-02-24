using System;
using UnityEngine;

namespace Npc
{
    public class NpcStats : MonoBehaviour
    {
        private const int MaxEnergy = 100;
        private const int MaxHunger = 100;
        private const int MaxMoney = 1000;

        [SerializeField] private float _decreaseEnergyTimeout;
        [SerializeField] private float _increaseHungerTimeout;

        private float _timeTillDecreaseEnergy;
        private float _timeTillIncreaseHunger;

        private int _energy;
        private int _hunger;
        private int _money;

        public int Energy
        {
            get => _energy;
            set
            {
                _energy = Math.Clamp(value, 0, MaxEnergy);
                OnStatsUpdated?.Invoke();
            }
        }

        public int Hunger
        {
            get => _hunger;
            set
            {
                _hunger = Math.Clamp(value, 0, MaxHunger);
                OnStatsUpdated?.Invoke();
            }
        }

        public int Money
        {
            get => _money;
            set
            {
                _money = Math.Clamp(value, 0, MaxMoney);
                OnStatsUpdated?.Invoke();
            }
        }

        public float MoneyNormalized => (float)_money / MaxMoney;
        public float EnergyNormalized => (float)_energy / MaxEnergy;
        public float HungerNormalized => (float)_hunger / MaxHunger;

        public event Action OnStatsUpdated;

        private void Start()
        {
            _energy = 100;
            _hunger = 0;
            _money = 50;

            _timeTillDecreaseEnergy = _decreaseEnergyTimeout;
            _timeTillIncreaseHunger = _increaseHungerTimeout;
        }

        public void TickEnergy(float deltaTime)
        {
            _timeTillDecreaseEnergy -= deltaTime;
            if (_timeTillDecreaseEnergy < 0)
            {
                Energy--;
                _timeTillDecreaseEnergy = _decreaseEnergyTimeout;
            }
        }

        public void TickHunger(float deltaTime)
        {
            _timeTillIncreaseHunger -= deltaTime;
            if (_timeTillIncreaseHunger < 0)
            {
                Hunger++;
                _timeTillIncreaseHunger = _increaseHungerTimeout;
            }
        }
    }
}