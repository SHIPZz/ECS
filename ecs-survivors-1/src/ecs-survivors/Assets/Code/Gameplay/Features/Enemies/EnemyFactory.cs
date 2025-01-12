using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at)
        {
            switch (enemyTypeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(enemyTypeId, at);
                
                default:
                    throw new Exception();
            }
        }

        private GameEntity CreateGoblin(EnemyTypeId enemyTypeId, Vector2 at)
        {
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddEnemyTypeId(enemyTypeId)
                    .AddSpeed(3f)
                    .AddDirection(Vector3.zero)
                    .AddDamage(10)
                    .AddCurrentHp(100)
                    .AddMaxHp(100)
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .AddDeathAnimationDuration(3f)
                    .AddTargetsBuffer(new List<int>(1))
                    .AddCollectTargetsInterval(0.5f)
                    .AddCollectTargetsTimer(0)
                    .AddRadius(0.3f)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .With(x => x.isTurnAlongDirection = true)
                    .With(x => x.isEnemy = true)
                    .With(x => x.isCollectingAvailable = true)
                    .With(x => x.isMovingAvailable = true)
                    .With(x => x.isReadyToCollectTargets = true)
                ;
        }
    }
}
