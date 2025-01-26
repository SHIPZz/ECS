using Code.Common.Configs;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    CollisionLayerConfig CollisionLayerConfig { get; }
    AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId);
    AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level);
    EnchantConfig GetEnchantConfig(EnchantTypeId enchantType);
    EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId);
    LootConfig GetLootConfig(LootTypeId lootTypeId);
  }
}