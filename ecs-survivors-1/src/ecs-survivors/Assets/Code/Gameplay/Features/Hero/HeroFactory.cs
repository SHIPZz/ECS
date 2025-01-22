﻿using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Hero.Factory;
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
            var baseStats = InitStats.EmptyStatDictionary()
                    .With( x=> x[Stats.Speed] = 6)
                    .With( x=> x[Stats.Scale] = 1)
                    .With( x=> x[Stats.Hp] = 100)
                    .With( x=> x[Stats.MaxHp] = 100)
                
                ;
            
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddDirection(Vector3.zero)
                    .AddDeathAnimationDuration(3f)
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddBaseStats(baseStats)
                    .AddViewPath("Gameplay/Hero/hero")
                    .SetupTargetCollectionComponents(_staticDataService.CollisionLayerConfig.PlayerMask)
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddCurrentHp(baseStats[Stats.Hp])
                    .AddMaxHp(baseStats[Stats.MaxHp])
                    .AddRadius(0.5f)
                    .AddScale(Vector3.one * baseStats[Stats.Scale])
                    .AddLayerMask(_staticDataService.CollisionLayerConfig.PlayerMask)
                    .With(entity => entity.isHero = true)
                    .With(entity => entity.isAlive = true)
                    .With(entity => entity.isMovingAvailable = true)
                    .With(entity => entity.AddVampireId(entity.Id))
                    .With(entity => entity.isTurnAlongDirection = true)
                ;
        }
    }
}