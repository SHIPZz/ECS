using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    [CreateAssetMenu(menuName = "Enemy config", fileName = "EnemyConfig")]
    public class EnemyConfig : SerializedScriptableObject
    {
        public EnemyTypeId EnemyTypeId;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public List<AuraSetup> AuraSetups;

        public CollisionLayer CollisionLayer;

        public float Radius = 1f;

        public EntityBehaviour ViewPrefab;

        [Space]
        [Header("Bleeding trail settings")] public float TrailSpawnCooldown;
        public float LongBleedingSpeed = 5f;
        public float SplashBleedingSpeed = 1f;
        public float TrailSpawnInterval = 0.5f;
        public float BleedTrailOffset = 0.5f;
        public float LongBleedTrailOffset = 0.25f;
        [OdinSerialize] public Dictionary<BleedingTrailTypeId, List<BleedingTrailData>> BleedingTrails = new();

        
        [Space]
        [Header("Kicking back settings")]
         public float KickingBackForce = 10f;
        public float KickingBackDamping = 3f;
        public float KickingBackStopForce = 0.1f;

        public float MovementSpeed = 0.2f;
        public float Hp = 1000;
        public float MaxHp = 1000;

        public AuraSetup GetAura(AuraTypeId auraTypeId) => AuraSetups.FirstOrDefault(x => x.AuraTypeId == auraTypeId);
    }
}