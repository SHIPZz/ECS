using System;

namespace Code.Meta.UI.GoldHolders.Service
{
    public interface IStorageUIService
    {
        event Action GoldChanged;
        float CurrentGold { get; }
        float CurrentGoldGainBoost { get; }
        void UpdateCurrentGold(float gold);
        event Action GoldBoostChanged;
        void UpdateGoldGainBoost(float boost);
    }
}