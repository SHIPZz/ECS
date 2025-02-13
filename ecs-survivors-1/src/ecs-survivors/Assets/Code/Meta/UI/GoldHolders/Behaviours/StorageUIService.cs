using System;

namespace Code.Meta.UI.GoldHolders.Behaviours
{
    public class StorageUIService : IStorageUIService
    {
        private float _currentGold;

        public event Action GoldChanged;

        public float CurrentGold => _currentGold;

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