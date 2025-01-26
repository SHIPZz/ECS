using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Configs
{
    [CreateAssetMenu(fileName = "LootConfig", menuName = "Gameplay/LootConfig")]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId Id;
        public float Experience;
        public EntityBehaviour ViewPrefab;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}