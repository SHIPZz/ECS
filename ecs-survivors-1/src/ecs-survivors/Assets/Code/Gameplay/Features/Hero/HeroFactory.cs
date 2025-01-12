using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector3 at)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddDirection(Vector3.zero)
                    .AddSpeed(3f)
                    .AddDeathAnimationTime(3f)
                    .AddCurrentHp(100)
                    .AddViewPath("Gameplay/Hero/hero")
                    .AddTargetsBuffer(new List<int>(128))
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0f)
                    .AddDamage(5)
                    .AddMaxHp(100)
                    .With(entity => entity.isHero = true)
                    .With(entity => entity.isMovingAvailable = true)
                    .With(entity => entity.isCollectingAvailable = true)
                    .With(entity => entity.isTurnAlongDirection = true)
                ;
        }
    }
}