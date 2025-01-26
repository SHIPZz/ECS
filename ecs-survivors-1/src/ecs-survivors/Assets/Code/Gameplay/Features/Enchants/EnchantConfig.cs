using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants
{
    [CreateAssetMenu(menuName = "Enchant config", fileName = "EnchantConfig")]
    public class EnchantConfig : ScriptableObject
    {
        public EnchantTypeId EnchantTypeId;
        public Sprite Icon;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public float Radius = 1f;

        public EntityBehaviour ViewPrefab;
    }
}