using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        public void Setup(ShopItemConfig config)
        {
            Icon.sprite = config.Icon;
            Price.text = $"{config.Price}";
            Duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
            Boost.text = config.Boost.ToString("+0%");
        }

        private void OnBuyButtonClicked(ShopItemConfig config)
        {
        }
    }
}