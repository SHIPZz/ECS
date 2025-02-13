using Code.Meta.UI.Shop.Items;
using UnityEngine;

public interface IShopUIFactory
{
    ShopItem CreateShopItem(ShopItemConfig config, Transform at);
}