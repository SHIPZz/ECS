using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrar
{
    public class EnemyRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2f;
        public EnemyTypeId EnemyTypeId;

        public override void RegisterComponents()
        {
            Entity
                .AddEnemyTypeId(EnemyTypeId)
                .AddSpeed(Speed)
                .AddDirection(Vector3.zero)
                .AddDamage(10)
                .AddCurrentHp(100)
                .AddMaxHp(100)
                .AddDeathAnimationTime(3f)
                .AddTargetsBuffer(new List<int>(1))
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddRadius(0.3f)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .AddWorldPosition(transform.position)
                .With(x => x.isTurnAlongDirection = true)
                .With(x => x.isEnemy = true)
                .With(x => x.isCollectingAvailable = true)
                .With(x => x.isMovingAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                ;
            
        }

        public override void UnregisterComponents()
        {
        }
    }
}