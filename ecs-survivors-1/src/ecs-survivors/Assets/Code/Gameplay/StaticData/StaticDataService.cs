using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Configs;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows.Configs;
using Code.Meta.Features.AfkGain.Conigs;
using Code.Meta.UI.Shop.Items;
using Resources.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityTypeId, AbilityConfig> _abilityConfigs;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantConfigs;
        private Dictionary<EnemyTypeId, EnemyConfig> _enemies;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        private LevelUpConfig _levelUpConfig;
        private AfkGainConfig _afkGainConfig;
        private List<ShopItemConfig> _shopItemConfigs;

        public AfkGainConfig AfkGainConfig => _afkGainConfig;

        public CollisionLayerConfig CollisionLayerConfig { get; private set; }

        public void LoadAll()
        {
            LoadCollisionLayerConfig();

            LoadAbilities();
            LoadEnchants();
            LoadEnemies();
            LoadLoot();
            LoadWindows();
            LoadLevelUpRules();
            LoadAfkGain();
            LoadShopItems();
        }

        private void LoadAfkGain()
        {
            _afkGainConfig = UnityEngine.Resources.Load<AfkGainConfig>("Configs/AfkGainConfig");
        }

        public void LoadShopItems()
        {
           _shopItemConfigs = UnityEngine.Resources.LoadAll<ShopItemConfig>("Configs/ShopItems")
                .ToList();
        }

        public ShopItemConfig GetShopItemConfig(ShopItemId shopItemId)
        {
            return _shopItemConfigs.FirstOrDefault(x => x.ShopItemId == shopItemId);
        }
        
        public List<ShopItemConfig> GetShopItemConfigs()
        {
            return _shopItemConfigs.ToList();
        }

        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        public AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId) => _abilityConfigs[abilityTypeId];

        public int MaxLevel() => _levelUpConfig.MaxLevel;

        public float ExperienceForLevel(int level) => _levelUpConfig.ExperienceForLevel[level];

        public EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId) => _enemies[enemyTypeId];

        public LootConfig GetLootConfig(LootTypeId lootTypeId) => _lootById[lootTypeId];

        public AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level)
        {
            AbilityConfig abilityConfig = _abilityConfigs[abilityTypeId];

            List<AbilityLevel> abilityLevels = abilityConfig.AbilityLevels;

            Debug.Log($"{abilityTypeId} - {level}");

            if (level > abilityLevels.Count)
                return abilityLevels[^1];

            return level - 1 < 0 ? abilityLevels[level] : abilityLevels[level - 1];
        }

        public EnchantConfig GetEnchantConfig(EnchantTypeId enchantType)
        {
            return _enchantConfigs[enchantType];
        }

        private void LoadCollisionLayerConfig()
        {
            CollisionLayerConfig = UnityEngine.Resources.Load<CollisionLayerConfig>("Configs/CollisionLayer/CollisionLayerConfig");
        }

        private void LoadAbilities()
        {
            _abilityConfigs = UnityEngine.Resources.LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityTypeId, x => x);
        }

        private void LoadWindows()
        {
            _windowPrefabsById = UnityEngine.Resources
                .Load<WindowsConfig>("Configs/Windows/WindowConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLoot()
        {
            _lootById = UnityEngine.Resources
                .LoadAll<LootConfig>("Configs/Loot")
                .ToDictionary(x => x.Id, x => x);
        }

        private void LoadEnemies()
        {
            _enemies = UnityEngine.Resources.LoadAll<EnemyConfig>("Configs/Enemies")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        private void LoadEnchants()
        {
            _enchantConfigs = UnityEngine.Resources.LoadAll<EnchantConfig>("Configs/Enchants")
                .ToDictionary(x => x.EnchantTypeId, x => x);
        }

        private void LoadLevelUpRules()
        {
            _levelUpConfig = UnityEngine.Resources.Load<LevelUpConfig>("Configs/LevelUp/LevelUpConfig");
        }
    }
}