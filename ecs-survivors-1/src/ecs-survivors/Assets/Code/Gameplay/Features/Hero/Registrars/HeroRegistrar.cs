using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        public float Speed = 3f;
        public HeroAnimator HeroAnimator;
        public SpriteRenderer Sprite;
        
        private IIdentifierService _identifierService;

        [Inject]
        private void Construct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        private void Awake()
        {
            CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(transform.position)
                .AddTransform(transform)
                .AddHeroAnimator(HeroAnimator)
                .AddSpriteRenderer(Sprite)
                .With(entity => entity.isHero = true)
                .With(entity => entity.isTurnAlongDirection = true)
                .AddDirection(Vector3.zero)
                .AddSpeed(Speed)
                ;
        }
    }
}