using System;
using System.Collections.Generic;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop
{
    public interface IShopUIService
    {
        void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItmes);
        List<ShopItemConfig> GetAvailableItems();
        void Cleanup();
        event Action ShopChanged;
        ShopItemConfig GetConfig(ShopItemId requestShopItemId);
        void UpdatePurchasedItem(ShopItemId requestShopItemId);
    }
}