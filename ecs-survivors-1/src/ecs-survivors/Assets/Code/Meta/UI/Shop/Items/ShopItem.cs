using System;
using Code.Common.Entity;
using Code.Meta.UI.GoldHolders.Behaviours;
using Code.Meta.UI.GoldHolders.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop.Items
{
    public class ShopItem : MonoBehaviour
    {
        public Image Icon;
        public TextMeshProUGUI Price;
        public TextMeshProUGUI Duration;
        public TextMeshProUGUI Boost;
        public Button BuyButton;
        public CanvasGroup CanvasGroup;

        public Color EnoughColor;
        public Color NotEnoughColor;

        private bool _isAvailable;
        private IStorageUIService _storageUIService;
        private int _price;
        private float _currentGold;
        private ShopItemId Id;

        private bool EnoughGold => _currentGold >= _price;

        [Inject]
        private void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        private void Start()
        {
            _storageUIService.GoldChanged += UpdatePriceThreshold;
        }

        private void OnEnable() => UpdatePriceThreshold();

        public void Setup(ShopItemConfig config)
        {
            Id = config.ShopItemId;
            Icon.sprite = config.Icon;
            Price.text = $"{config.Price}";
            Duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
            Boost.text = config.Boost.ToString("+0%");

            _price = config.Price;

            BuyButton.onClick.AddListener(BuyItem);
        }

        private void OnDestroy()
        {
            _storageUIService.GoldChanged -= UpdatePriceThreshold;
            BuyButton.onClick.RemoveListener(BuyItem);
        }

        private void BuyItem()
        {
            CreateMetaEntity
                .Empty()
                .AddShopItemId(Id)
                .isBuyRequest = true;
        }

        private void UpdatePriceThreshold()
        {
            _currentGold = _storageUIService.CurrentGold;
            Debug.Log($"{_storageUIService.CurrentGold}");
            Price.color = EnoughGold ? EnoughColor : NotEnoughColor;
        }

        public void UpdateAvailability(bool itemsCanBeBought)
        {
            _isAvailable = itemsCanBeBought;

            if (CanvasGroup != null)
                CanvasGroup.alpha = _isAvailable ? 1f : 0.7f;

            if (BuyButton != null)
                BuyButton.interactable = _isAvailable && EnoughGold;
        }
    }
}