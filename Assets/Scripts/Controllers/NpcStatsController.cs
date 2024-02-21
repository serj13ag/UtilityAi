using System;
using Ui;
using UnityEngine;

namespace Controllers
{
    public class NpcStatsController : MonoBehaviour
    {
        private const int MaxEnergy = 100;
        private const int MaxHunger = 100;
        private const int MaxMoney = 1000;
        
        [SerializeField] private NpcView _npcView;

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
                _npcView.UpdateStats(this);
            }
        }

        public int Hunger
        {
            get => _hunger;
            set
            {
                _hunger = Math.Clamp(value, 0, MaxHunger);
                _npcView.UpdateStats(this);
            }
        }

        public int Money
        {
            get => _money;
            set
            {
                _money = Math.Clamp(value, 0, MaxMoney);
                _npcView.UpdateStats(this);
            }
        }

        private void Start()
        {
            _energy = 100;
            _hunger = 0;
            _money = 50;

            _timeTillDecreaseEnergy = _decreaseEnergyTimeout;
            _timeTillIncreaseHunger = _increaseHungerTimeout;

            _npcView.UpdateStats(this);
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