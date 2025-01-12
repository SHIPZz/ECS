using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

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
                .AddCurrentHp(100)
                .AddDamage(5)
                .AddMaxHp(100)
                .With(entity => entity.isHero = true)
                .With(entity => entity.isTurnAlongDirection = true)
                ;
        }

        public override void UnregisterComponents()
        {
        }
    }
}