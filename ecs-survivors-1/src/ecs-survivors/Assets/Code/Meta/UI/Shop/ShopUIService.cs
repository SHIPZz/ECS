using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop
{
    public class ShopUIService
    {
        private List<ShopItemId> _purchasedItems = new();
        private Dictionary<ShopItemId, ShopItemConfig> _availableShopItems = new();
        private IStaticDataService _staticDataService;

        public ShopUIService(IStaticDataService staticDataService) => _staticDataService = staticDataService;

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItmes)
        {
            _purchasedItems.AddRange(purchasedItmes);

            RefreshAvailableItems();
        }

        public List<ShopItemConfig> GetAvailableItems() => new(_availableShopItems.Values);

        private void RefreshAvailableItems()
        {
            
        }
    }
}