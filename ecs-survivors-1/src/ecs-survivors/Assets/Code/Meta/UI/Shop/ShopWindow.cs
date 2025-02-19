using System;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using Code.Meta.UI.GoldHolders.Service;
using Code.Meta.UI.Shop.Items;
using Resources.Gameplay.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop
{
    public class ShopWindow : BaseWindow
    {
        public Transform ItemsLayout;
        public Button CloseButton;
        public GameObject NoItemsAvailable;

        private readonly List<ShopItem> _items = new();
    
        private IWindowService _windowService;
        private IShopUIFactory _shopUIFactory;
        private IShopUIService _shopUIService;
        private IStorageUIService _storageUIService;

        [Inject]
        private void Construct(IWindowService windowService, 
            IShopUIFactory shopUIFactory,
            IShopUIService shopUIService,
            IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
            _shopUIService = shopUIService;
            _shopUIFactory = shopUIFactory;
            Id = WindowId.ShopWindow;

            _windowService = windowService;
        }

        protected override void Initialize()
        {
            CloseButton.onClick.AddListener(Close);
        }

        protected override void SubscribeUpdates()
        {
            _shopUIService.ShopChanged += Refresh;
            _storageUIService.GoldBoostChanged += UpdateBoosterState;
        
            Refresh();
        }

        protected override void UnsubscribeUpdates()
        {
            _shopUIService.ShopChanged -= Refresh;
            CloseButton.onClick.RemoveListener(Close);
        }

        private void UpdateBoosterState()
        {
            bool itemsCanBeBought = _storageUIService.CurrentGoldGainBoost <= float.Epsilon;

            Debug.Log($"{_storageUIService.CurrentGoldGainBoost}");
            Debug.Log($"{itemsCanBeBought}");
            
            foreach (ShopItem shopItem in _items)
            {
                shopItem.UpdateAvailability(itemsCanBeBought);
            }
        }

        private void Refresh()
        {
            ClearItems();
        
            List<ShopItemConfig> availableItems = _shopUIService.GetAvailableItems();

            NoItemsAvailable.SetActive(availableItems.Count == 0);
        
            FillItems(availableItems);
            UpdateBoosterState();
        }

        private void ClearItems()
        {
            _items.ForEach(x => Destroy(x.gameObject));
            _items.Clear();
        }

        private void FillItems(List<ShopItemConfig> availableItems)
        {
            foreach (ShopItemConfig shopItemConfig in availableItems)
                _items.Add(_shopUIFactory.CreateShopItem(shopItemConfig, ItemsLayout));
        }

        private void Close()
        {
            _windowService.Close(Id);
        }
    }
}