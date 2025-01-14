using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
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
        
        public GameEntity CreateScatteringBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Scattering, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddDamage(projectileSetup.Damage)
                    .AddSpeed(projectileSetup.Speed)
                    .AddTargetLimit(projectileSetup.Pierce)
                    .AddScale(Vector3.one)
                    .AddContactRadius(projectileSetup.ContactRadius)
                    .AddRadius(projectileSetup.ContactRadius)
                    .AddScatteringCount(projectileSetup.ScatteringCount)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddWorldPosition(at)
                    .AddSelfDestructTimer(projectileSetup.Lifetime)
                    .AddFollowMaxDistance(0.1f)
                    .AddProcessedTargetsBuffer(new List<int>(16))
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), projectileSetup.CollectTargetInterval)
                    .With(x => x.isScatteringArmament = true)
                    .With(x => x.isArmament = true)
                    .With(x => x.isFollowNewCloseTarget = true)
                    .With(x => x.isRotateAlongDirection = true)
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
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), projectileSetup.CollectTargetInterval)
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

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddDamage(projectileSetup.Damage)
                    .AddSpeed(projectileSetup.Speed)
                    .AddContactRadius(projectileSetup.ContactRadius)
                    .AddRadius(projectileSetup.ContactRadius)
                    .AddTargetLimit(projectileSetup.Pierce)
                    .AddSelfDestructTimer(projectileSetup.Lifetime)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddWorldPosition(at)
                    .AddProcessedTargetsBuffer(new List<int>(16))
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), projectileSetup.CollectTargetInterval)
                    .With(x => x.isRadialBoltArmament = true)
                    .With(x => x.isArmament = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.VegetableBolt, level);
            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            LayerMask mask = _staticDataService.CollisionLayerConfig.PlayerProjectileMask;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddDamage(projectileSetup.Damage)
                    .AddSpeed(projectileSetup.Speed)
                    .AddContactRadius(projectileSetup.ContactRadius)
                    .AddRadius(projectileSetup.ContactRadius)
                    .AddTargetLimit(projectileSetup.Pierce)
                    .AddSelfDestructTimer(projectileSetup.Lifetime)
                    .AddViewPrefab(abilityLevel.Prefab)
                    .AddWorldPosition(at)
                    .AddProcessedTargetsBuffer(new List<int>(16))
                    .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(),
                        projectileSetup.CollectTargetInterval)
                    .With(x => x.isVegetableBoltArmament = true)
                    .With(x => x.isArmament = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                    .With(x => x.isRotateAlongDirection = true)
                ;
        }
    }
}