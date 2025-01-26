using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Effects;
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

        public AuraSetup GetAura(AuraTypeId auraTypeId) => AuraSetups.FirstOrDefault(x => x.AuraTypeId == auraTypeId);

    }
}