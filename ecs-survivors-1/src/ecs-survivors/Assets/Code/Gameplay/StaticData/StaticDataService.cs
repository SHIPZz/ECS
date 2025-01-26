using System.Collections.Generic;
using System.Linq;
using Code.Common.Configs;
using Code.Gameplay.Features.Ability;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityTypeId, AbilityConfig> _abilityConfigs;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantConfigs;
        private Dictionary<EnemyTypeId, EnemyConfig> _enemies;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        
        public CollisionLayerConfig CollisionLayerConfig { get; private set; }

        public void LoadAll()
        {
            LoadCollisionLayerConfig();

            LoadAbilities();
            LoadEnchants();
            LoadEnemies();
            LoadLoot();
        }

        public AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId) => _abilityConfigs[abilityTypeId];

        public EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId) => _enemies[enemyTypeId];
        
        public LootConfig GetLootConfig(LootTypeId lootTypeId) => _lootById[lootTypeId];

        public AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level)
        {
            AbilityConfig abilityConfig = _abilityConfigs[abilityTypeId];

            List<AbilityLevel> abilityLevels = abilityConfig.AbilityLevels;
            
            return abilityLevels.Count > level ? abilityLevels[^1] : abilityLevels[level - 1];
        }

        public EnchantConfig GetEnchantConfig(EnchantTypeId enchantType)
        {
            return _enchantConfigs[enchantType];
        }

        private void LoadCollisionLayerConfig()
        {
            CollisionLayerConfig = Resources.Load<CollisionLayerConfig>("Configs/CollisionLayer/CollisionLayerConfig");
        }

        private void LoadAbilities()
        {
            _abilityConfigs = Resources.LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityTypeId, x => x);
        }

        private void LoadLoot()
        {
            _lootById = Resources
                .LoadAll<LootConfig>("Configs/Loot")
                .ToDictionary(x => x.Id, x => x);
        }

        private void LoadEnemies()
        {
            _enemies = Resources.LoadAll<EnemyConfig>("Configs/Enemies")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        private void LoadEnchants()
        {
            _enchantConfigs = Resources.LoadAll<EnchantConfig>("Configs/Enchants")
                .ToDictionary(x => x.EnchantTypeId, x => x);
        }
    }
}