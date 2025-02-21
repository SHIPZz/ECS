using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.StaticData;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop
{
    public class ShopUIService : IShopUIService
    {
        private readonly List<ShopItemId> _purchasedItems = new();
        private readonly Dictionary<ShopItemId, ShopItemConfig> _availableShopItems = new();
        private readonly IStaticDataService _staticDataService;
        
        public event Action ShopChanged;

        public ShopUIService(IStaticDataService staticDataService) => _staticDataService = staticDataService;

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItmes)
        {
            _purchasedItems.AddRange(purchasedItmes);

            RefreshAvailableItems();
        }

        public void Cleanup()
        {
            _purchasedItems.Clear();
            _availableShopItems.Clear();

            ShopChanged = null;
        }

        public List<ShopItemConfig> GetAvailableItems() => new(_availableShopItems.Values);

        public ShopItemConfig GetConfig(ShopItemId requestShopItemId)
        {
            return _availableShopItems.GetValueOrDefault(requestShopItemId);
        }

        public void UpdatePurchasedItem(ShopItemId requestShopItemId)
        {
            _availableShopItems.Remove(requestShopItemId);
            _purchasedItems.Add(requestShopItemId);
            
            ShopChanged?.Invoke();
        }

        private void RefreshAvailableItems()
        {
            foreach (ShopItemConfig shopItemConfig in _staticDataService.GetShopItemConfigs())
            {
                if (!_purchasedItems.Contains(shopItemConfig.ShopItemId))
                    _availableShopItems.Add(shopItemConfig.ShopItemId, shopItemConfig);
            }
            
            ShopChanged?.Invoke();
        }
    }
}