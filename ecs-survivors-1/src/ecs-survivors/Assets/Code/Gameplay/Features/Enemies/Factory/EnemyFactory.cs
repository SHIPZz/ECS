using System;
using Code.Common.Entity;
using Code.Common.Extensions;
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
                    .AddSpeed(1.5f)
                    .AddDirection(Vector3.zero)
                    .AddDamage(0.5f)
                    .AddCurrentHp(100)
                    .AddMaxHp(100)
                    .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
                    .AddDeathAnimationDuration(3f)
                    .SetupTargetCollectionComponents(_staticDataService.CollisionLayerConfig.EnemyMask)
                    .AddRadius(0.3f)
                    .AddLayerMask(CollisionLayer.Hero.AsMask())
                    .With(x => x.isTurnAlongDirection = true)
                    .With(x => x.isEnemy = true)
                    .With(x => x.isAlive = true)
                    .With(x => x.AddVampireId(x.Id))
                    .With(x => x.isMovingAvailable = true)
                ;
        }
    }
}
