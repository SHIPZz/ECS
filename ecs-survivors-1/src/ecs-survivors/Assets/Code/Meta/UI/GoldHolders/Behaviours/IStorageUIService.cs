using System;

namespace Code.Meta.UI.GoldHolders.Behaviours
{
    public interface IStorageUIService
    {
        event Action GoldChanged;
        float CurrentGold { get; }
        void UpdateCurrentGold(float gold);
    }
}