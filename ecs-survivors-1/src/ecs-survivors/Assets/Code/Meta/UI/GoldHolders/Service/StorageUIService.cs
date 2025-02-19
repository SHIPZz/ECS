using System;
using UnityEngine;

namespace Code.Meta.UI.GoldHolders.Service
{
    public class StorageUIService : IStorageUIService
    {
        private float _currentGold;
        private float _goldGainBoost;

        public event Action GoldChanged;
        public event Action GoldBoostChanged;

        public float CurrentGold => _currentGold;
        public float CurrentGoldGainBoost => _goldGainBoost;
        
        public void UpdateGoldGainBoost(float boost)
        {
            _goldGainBoost = boost;
            
            GoldBoostChanged?.Invoke();
        }

        public void UpdateCurrentGold(float gold)
        {
            if (Math.Abs(gold - _currentGold) > float.Epsilon)
            {
                _currentGold = gold;
                GoldChanged?.Invoke();
            }
        }
    }
}