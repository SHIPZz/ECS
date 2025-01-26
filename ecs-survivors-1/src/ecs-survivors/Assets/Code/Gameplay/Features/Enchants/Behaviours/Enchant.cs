using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        public Image Icon;
        public EnchantTypeId Id;

        public void Set(EnchantConfig enchantConfig)
        {
            Icon.sprite = enchantConfig.Icon;
            Id = enchantConfig.EnchantTypeId;
        }
    }
}