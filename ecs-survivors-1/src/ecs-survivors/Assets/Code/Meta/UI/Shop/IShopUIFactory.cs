﻿using Code.Meta.UI.Shop.Items;
using UnityEngine;

namespace Code.Meta.UI.Shop
{
    public interface IShopUIFactory
    {
        ShopItem CreateShopItem(ShopItemConfig config, Transform at);
    }
}