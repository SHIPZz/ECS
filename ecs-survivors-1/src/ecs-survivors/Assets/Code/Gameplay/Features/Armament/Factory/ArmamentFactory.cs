using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armament.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IIdentifierService _identifierService;

        public ArmamentFactory(IStaticDataService staticDataService, IIdentifierService identifierService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateSpecialBomb(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.SpecialBomb, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.SpecialBomb)
                    .With(x => x.AddIgnoreBuffer(new List<int>(32)))
                    .AddScatteringCount(projectileSetup.ScatteringCount)
                    .With(x => x.AddAbilityHolder(new List<AbilityTypeId>(32)))
                    .With(x => x.AbilityHolder.Add(AbilityTypeId.FireAura))
                    .With(x => x.isReadyToCollectOnMovingFinished = true)
                    .With(x => x.isCollectingAvailable = false)
                ;
        }

        public GameEntity CreateScatteringBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Scattering, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.Scattering)
                    .AddScale(Vector3.one)
                    .With(x => x.AddIgnoreBuffer(new List<int>(32)))
                    .AddScatteringCount(projectileSetup.ScatteringCount)
                    .With(x => x.isScatteringArmament = true)
                ;
        }

        public GameEntity CreateBouncingBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Bounce, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddDamage(projectileSetup.Damage)
                    .AddSpeed(projectileSetup.Speed)
                    .AddTargetLimit(projectileSetup.BouncingCount)
                    .AddContactRadius(projectileSetup.ContactRadius)
                    .AddRadius(projectileSetup.ContactRadius)
                    .AddMaxBouncingCount(projectileSetup.BouncingCount)
                    .AddFollowMaxDistance(0.1f)
                    .AddBouncingCount(0)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddWorldPosition(at)
                    .AddProcessedTargetsBuffer(new List<int>(16))
                    .AddLastFollowTargets(new List<int>(64))
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(),
                        projectileSetup.CollectTargetInterval)
                    .With(x => x.isBouncingArmament = true)
                    .With(x => x.isArmament = true)
                    .With(x => x.isFollowNewCloseTarget = true)
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }

        public GameEntity CreateRadialBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Radial, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.Radial)
                    .With(x => x.isRadialBoltArmament = true)
                ;
        }

        public GameEntity CreateAura(AbilityTypeId parentAbilityId, AuraSetup auraSetup, int producerId)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddSelfDestructTimer(auraSetup.Lifetime)
                .AddContactRadius(auraSetup.Radius)
                .AddProducerId(producerId)
                .AddParentAbility(parentAbilityId)
                .AddWorldPosition(Vector3.zero)
                .AddRadius(auraSetup.Radius)
                .AddViewPrefab(auraSetup.Prefab)
                .AddLayerMask(auraSetup.LayerMask)
                .SetupTargetCollectionComponents(auraSetup.LayerMask, auraSetup.Interval)
                .With(x => x.AddEffectSetups(new List<EffectSetup>(auraSetup.EffectSetups)), when: !auraSetup.EffectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(new List<StatusSetup>(auraSetup.StatusSetups)), when: !auraSetup.StatusSetups.IsNullOrEmpty())
                .With(x => x.isCollectingTargetsContinuously = true)
                .With(x => x.isAura = true)
                .With(x => x.isFollowingProducer = true);
        }
        
        public GameEntity CreateFireAura(AbilityTypeId parentAbilityId, int producerId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.FireAura, level);
            AuraSetup auraSetup = abilityLevel.AuraSetup;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddContactRadius(auraSetup.Radius)
                    .AddProducerId(producerId)
                    .AddParentAbility(parentAbilityId)
                    .AddWorldPosition(Vector3.zero)
                    .AddRadius(auraSetup.Radius)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), auraSetup.Interval)
                    .With(x => x.AddEffectSetups(new List<EffectSetup>(abilityLevel.EffectSetups)), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(new List<StatusSetup>(abilityLevel.StatusSetups)), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isFollowingProducer = true)
                ;
        }

        public GameEntity CreateEffectAura(AbilityTypeId parentAbilityId, int producerId, int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.GarlicAura, level);
            AuraSetup auraSetup = abilityLevel.AuraSetup;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddContactRadius(auraSetup.Radius)
                    .AddProducerId(producerId)
                    .AddParentAbility(parentAbilityId)
                    .AddWorldPosition(Vector3.zero)
                    .AddRadius(auraSetup.Radius)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), auraSetup.Interval)
                    .With(x => x.AddEffectSetups(new List<EffectSetup>(abilityLevel.EffectSetups)), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(new List<StatusSetup>(abilityLevel.StatusSetups)), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isFollowingProducer = true)
                ;
        }
        
        public GameEntity CreateOrbitalMushroom(int level, Vector3 at, float phase)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.OrbitalMushroom, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddOrbitRadius(projectileSetup.OrbitRadius)
                    .AddOrbitPhase(phase)
                    .AddParentAbility(AbilityTypeId.OrbitalMushroom)
                    .With(x => x.isOrbitalMushroomArmament = true)
                ;
        }
        
        public GameEntity CreateExplosion(int producerId, Vector3 at)
        {
            EnchantConfig enchantConfig = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveEnchant);
            
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddProducerId(producerId)
                    .AddRadius(enchantConfig.Radius)
                    .AddViewPrefab(enchantConfig.ViewPrefab)
                    .AddEnchantTypeId(EnchantTypeId.ExplosiveEnchant)
                    .AddSelfDestructTimer(1f)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask())
                    .With(x => x.AddEffectSetups(new List<EffectSetup>(enchantConfig.EffectSetups)), when: !enchantConfig.EffectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(new List<StatusSetup>(enchantConfig.StatusSetups)), when: !enchantConfig.StatusSetups.IsNullOrEmpty())
                ;
        }

        public GameEntity CreatePullBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Magnificent, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.Magnificent)
                    .With(x => x.isVegetableBoltArmament = true)
                    .With(x => x.isPullingArmament = true)
                    .With(x => x.isPullingDetector = true)
                    .With(x => x.AddIgnoreBuffer(new List<int>(32)))
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }
        
        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.VegetableBolt, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.VegetableBolt)
                    .With(x => x.isVegetableBoltArmament = true)
                    .With(x => x.isBleedingProvocateurArmament = true)
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }
        
        public GameEntity CreateMagnificentBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Magnificent, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateProjectile(at, projectileSetup, abilityLevel)
                    .AddParentAbility(AbilityTypeId.VegetableBolt)
                    .With(x => x.isMagnificentBoltArmament = true)
                    .With(x => x.AddAdditionalProjectileCount(projectileSetup.AdditionalProjectileCount))
                    .With(x => x.AddAdditionalProjectileHitCount(projectileSetup.AdditionalProjectileHitCount))
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }

        private GameEntity CreateProjectile(Vector3 at, ProjectileSetup projectileSetup, AbilityLevel abilityLevel)
        {
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddSpeed(projectileSetup.Speed)
                    .AddContactRadius(projectileSetup.ContactRadius)
                    .AddRadius(projectileSetup.ContactRadius)
                    .AddSelfDestructTimer(projectileSetup.Lifetime)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddWorldPosition(at)
                    .AddLayerMask(CollisionLayer.Enemy.AsMask())
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), projectileSetup.CollectTargetInterval)
                    .With(x => x.isArmament = true)
                    .With(x => x.AddProcessedTargetsBuffer(new List<int>(16)), when: projectileSetup.Pierce > 0)
                    .With(x => x.AddTargetLimit(projectileSetup.Pierce), when: projectileSetup.Pierce > 0)
                    .With(x => x.AddEffectSetups(new List<EffectSetup>(abilityLevel.EffectSetups)), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                    .With(x => x.AddStatusSetups(new List<StatusSetup>(abilityLevel.StatusSetups)), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                    .With(x => x.isCollectingTargetsContinuously = true)
                ;
        }
    }
}