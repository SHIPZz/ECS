using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Factory;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnSingleSplashOnBleedingStartedSystem : ReactiveSystem<GameEntity>
    {
        private readonly IBleedingTrailEntityFactory _bleedingTrailEntityFactory;

        public SpawnSingleSplashOnBleedingStartedSystem(GameContext context, IBleedingTrailEntityFactory bleedingTrailEntityFactory)
            : base(context)
        {
            _bleedingTrailEntityFactory = bleedingTrailEntityFactory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.BleedingRequested.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWorldPosition &&
                   entity.isAlive &&
                   entity.isBleedingAvailable &&
                   entity.hasBleedingTrails;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Vector3 direction = entity.Direction.normalized;

                BleedingTrailData randomTrail = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();

                Vector3 targetPosition = entity.WorldPosition + direction * entity.BleedTrailOffset;

               GameEntity createdTrailEntity = _bleedingTrailEntityFactory.Create(entity.WorldPosition, Quaternion.identity, null, randomTrail)
                    .With(x => x.ReplaceDirection(direction))
                    ;

               createdTrailEntity.BleedTrailView.MoveTowardsByTween(targetPosition);
            }
        }
    }
}