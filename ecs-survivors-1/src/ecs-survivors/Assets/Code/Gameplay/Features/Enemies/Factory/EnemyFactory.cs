using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at)
        {
            switch (enemyTypeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(enemyTypeId, at);
                
                case EnemyTypeId.Healer:
                    return CreateHealer(enemyTypeId, at);
                
                case EnemyTypeId.Buffer:
                    return CreateBuffer(enemyTypeId, at);
                
                default:
                    throw new Exception();
            }
        }
        
        private GameEntity CreateBuffer(EnemyTypeId enemyTypeId, Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                    .With( x=> x[Stats.Speed] = 1)
                    .With( x=> x[Stats.MaxHp] = 100)
                    .With( x=> x[Stats.Scale] = 1)
                    .With( x=> x[Stats.Damage] = 5)
                ;

            var scale = baseStats[Stats.Scale];
            
            return CreateEnemy(enemyTypeId, at, baseStats, scale)
                .With(x => x.isBuffer = true)
                .AddCooldown(5f)
                .PutOnCooldown()
                .With(x => x.AddIgnoreBuffer(new List<int> {x.Id}))
                ;
        }
        
        private GameEntity CreateHealer(EnemyTypeId enemyTypeId, Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                    .With( x=> x[Stats.Speed] = 1)
                    .With( x=> x[Stats.MaxHp] = 100)
                    .With( x=> x[Stats.Scale] = 1)
                    .With( x=> x[Stats.Damage] = 5)
                
                ;

            var scale = baseStats[Stats.Scale];
            
            EnemyConfig enemyConfig = _staticDataService.GetEnemyConfig(enemyTypeId);
            
            return CreateEnemy(enemyTypeId, at, baseStats, scale)
                .With(x => x.AddIgnoreBuffer(new List<int> {x.Id}))
                .With(x => x.isHealer = true)
                .AddCooldown(5f)
                .AddCooldownLeft(0f)
                .With(x => x.PutOnCooldown())
                ;
        }

        private GameEntity CreateGoblin(EnemyTypeId enemyTypeId, Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With( x=> x[Stats.Scale] = 1)
                .With( x=> x[Stats.Damage] = 5)
                
                ;

            var scale = baseStats[Stats.Scale];
            
            return CreateEnemy(enemyTypeId, at, baseStats, scale)
                .With(x => x.isChaseHero = true)
                ;
        }

        private GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at, Dictionary<Stats, float> baseStats, float scale)
        {
            EnemyConfig enemyConfig = _staticDataService.GetEnemyConfig(enemyTypeId);

            baseStats[Stats.Speed] = enemyConfig.MovementSpeed;
            baseStats[Stats.MaxHp] = enemyConfig.MaxHp;
            baseStats[Stats.Hp] = enemyConfig.Hp;

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddEnemyTypeId(enemyTypeId)
                    .AddSpeed(baseStats[Stats.Speed])
                    .AddBleedingTrailView(enemyConfig.TrailView)
                    .AddBleedingTrailSpawnCooldown(enemyConfig.TrailSpawnCooldown)
                    .AddBleedingTrailSpawnCooldownLeft(enemyConfig.TrailSpawnCooldown)
                    .AddLongBleedTrailSpeed(enemyConfig.LongBleedingSpeed)
                    .AddSplashBleedTrailSpeed(enemyConfig.SplashBleedingSpeed)
                    .AddScale(new Vector3(scale, scale, scale))
                    .AddDirection(Vector3.zero)
                    .AddKickingBackDamping(enemyConfig.KickingBackDamping)
                    .AddKickingBackStopForce(enemyConfig.KickingBackStopForce)
                    .ReplaceKickingBackInitialForce(enemyConfig.KickingBackForce)
                    .AddKickingBackForce(enemyConfig.KickingBackForce)
                    .AddBleedingTrails(enemyConfig.BleedingTrails)
                    .AddBleedTrailSpawnInterval(enemyConfig.TrailSpawnInterval)
                    .AddBleedTrailOffset(enemyConfig.BleedTrailOffset)
                    .AddLongBleedTrailOffset(enemyConfig.LongBleedTrailOffset)
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddBaseStats(baseStats)
                    .AddEffectSetups(enemyConfig.EffectSetups.ToList())
                    .AddCurrentHp(baseStats[Stats.MaxHp])
                    .AddMaxHp(baseStats[Stats.MaxHp])
                    .AddViewPrefab(enemyConfig.ViewPrefab)
                    .AddDeathAnimationDuration(3f)
                    .AddLastBleedTrailSpawnTime(0)
                    .ReplaceInitialSpeed(enemyConfig.MovementSpeed)
                    .SetupTargetCollectionComponents(enemyConfig.CollisionLayer.AsMask())
                    .AddRadius(enemyConfig.Radius)
                    .AddLayerMask(enemyConfig.CollisionLayer.AsMask())
                    .AddAppliedEffectTypeIdsOnTarget(new List<EffectTypeId>(12))
                    .With(x => x.isTurnAlongDirection = true)
                    .With(x => x.AddStatusSetups(enemyConfig.StatusSetups.ToList()),when: enemyConfig.StatusSetups.Count > 0)
                    .With(x => x.isEnemy = true)
                    .With(x => x.isAlive = true)
                    .With(x => x.isKickingBackAvailable = true)
                    .With(x => x.isBleedingTrailSpawnCooldownUp = true)
                    .With(x => x.isMovingAvailable = true)
                    .With(x => x.isDontDestroyOnGameOver = true)
                ;
        }
    }
}
