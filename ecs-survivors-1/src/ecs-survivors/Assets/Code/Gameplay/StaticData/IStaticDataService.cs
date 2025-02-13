using Code.Common.Configs;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Meta.Features.AfkGain.Conigs;
using Code.Meta.UI.Shop.Items;
using Resources.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    CollisionLayerConfig CollisionLayerConfig { get; }
    AfkGainConfig AfkGainConfig { get; }
    AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId);
    AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level);
    EnchantConfig GetEnchantConfig(EnchantTypeId enchantType);
    EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId);
    LootConfig GetLootConfig(LootTypeId lootTypeId);
    GameObject GetWindowPrefab(WindowId id);
    int MaxLevel();
    float ExperienceForLevel(int level);
    ShopItemConfig GetShopItemConfig(ShopItemId shopItemId);
  }
}