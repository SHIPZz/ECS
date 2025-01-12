using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        public float Speed = 3f;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector3.zero)
                .AddSpeed(Speed)
                .AddDeathAnimationTime(3f)
                .AddCurrentHp(100)
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

        public override void UnregisterComponents()
        {
        }
    }
}