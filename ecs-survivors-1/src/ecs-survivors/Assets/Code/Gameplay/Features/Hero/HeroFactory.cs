using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public HeroFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddDirection(Vector3.zero)
                    .AddSpeed(3f)
                    .AddDeathAnimationDuration(3f)
                    .AddCurrentHp(1230232)
                    .AddViewPath("Gameplay/Hero/hero")
                    .SetupTargetCollectionComponents(_staticDataService.CollisionLayerConfig.PlayerMask)
                    .AddDamage(3)
                    .AddMaxHp(100)
                    .AddRadius(0.5f)
                    .AddLayerMask(_staticDataService.CollisionLayerConfig.PlayerMask)
                    .With(entity => entity.isHero = true)
                    .With(entity => entity.isMovingAvailable = true)
                    .With(entity => entity.isTurnAlongDirection = true)
                ;
        }
    }
}