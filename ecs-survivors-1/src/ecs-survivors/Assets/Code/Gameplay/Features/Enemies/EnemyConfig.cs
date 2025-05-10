using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    [CreateAssetMenu(menuName = "Enemy config", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public List<AuraSetup> AuraSetups;

        public CollisionLayer CollisionLayer;

        public float Radius = 1f;

        public EntityBehaviour ViewPrefab;
        
        [SerializeField] public float TrailSpawnCooldown;
        
        public BleedingTrailView TrailView;
        public float MovementSpeed = 0.2f;
        
        [SerializeField] public float KickingBackCooldown = 1f;
        [SerializeField] public float KickingBackForce = 10f;
        
        public List<BleedingTrailData> FinalBleedingTrails = new();
        public List<BleedingTrailData> InitialBleedingTrails = new();
        public List<BleedingTrailData> LongBleedingTrails = new();

        public float Hp = 1000;
        public float MaxHp = 1000;
        public float TrailSpawnInterval = 0.5f;
        public float BleedTrailOffset = 0.5f;
        public float LongBleedTrailOffset = 0.25f;

        public AuraSetup GetAura(AuraTypeId auraTypeId) => AuraSetups.FirstOrDefault(x => x.AuraTypeId == auraTypeId);

    }
}