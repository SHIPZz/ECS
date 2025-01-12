using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armament
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

        public GameEntity CreateVegetableBolt(int level, Vector3 at)
        {
            ProjectileSetup projectileSetup = _staticDataService.GetAbilityLevel(AbilityTypeId.VegetableBolt, level).ProjectileSetup;

            LayerMask mask = _staticDataService.CollisionLayerConfig.PlayerProjectileMask;
            
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddDamage(projectileSetup.Damage)
                .AddSpeed(projectileSetup.Speed)
                .AddRadius(0.3f)
                .AddTargetLimit(projectileSetup.Pierce)
                .AddViewPrefab(projectileSetup.Prefab)
                .AddWorldPosition(at)
                .SetupTargetCollectionComponents(CollisionLayer.Enemy.AsMask(), projectileSetup.CollectTargetInterval)
                .With(x => x.isVegetableBolt = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .With(x => x.isTurnAlongDirection = true)
                ;
        }
    }
}