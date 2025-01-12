using System.Collections.Generic;
using System.Linq;
using Code.Common.Configs;
using Code.Gameplay.Features.Ability;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityTypeId, AbilityConfig> _abilityConfigs;
        public CollisionLayerConfig CollisionLayerConfig { get; private set; }

        public void LoadAll()
        {
            CollisionLayerConfig = Resources.Load<CollisionLayerConfig>("Configs/CollisionLayer/CollisionLayerConfig");

            _abilityConfigs = Resources.LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityTypeId , x => x);
        }

        public AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId) => _abilityConfigs[abilityTypeId];

        public AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level)
        {
            AbilityConfig abilityConfig = _abilityConfigs[abilityTypeId];

            List<AbilityLevel> abilityLevels = abilityConfig.AbilityLevels;
            
            return abilityLevels.Count > level ? abilityLevels[^1] : abilityLevels[level - 1];
        }
    }
}