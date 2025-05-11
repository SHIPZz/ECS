using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using DG.Tweening;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnInitialTrailOnKickingBackStartedSystem : ReactiveSystem<GameEntity>
    {
        private readonly IInstantiator _instantiator;

        public SpawnInitialTrailOnKickingBackStartedSystem(GameContext context, IInstantiator instantiator)
            : base(context)
        {
            _instantiator = instantiator;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.KickingBacking.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWorldPosition &&
                   entity.isAlive &&
                   entity.hasBleedingTrails &&
                   entity.hasBleedingTrailView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                Vector3 direction = entity.Direction.normalized;

                Quaternion rotationAlignDirection = GetRotationFromDirection(direction);
                BleedingTrailData initialTrail = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();

                Vector3 startPosition = entity.WorldPosition + direction;
                Vector3 endPosition = entity.WorldPosition + direction * entity.BleedTrailOffset;

                var trailView = _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                    initialTrail.Prefab,
                    startPosition,
                    rotationAlignDirection,
                    null);

                float duration = 0.2f;

                trailView.transform.DOMove(endPosition, duration)
                    .SetEase(Ease.OutCubic);
            }
        }

        private static Quaternion GetRotationFromDirection(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotationAlignDirection = Quaternion.Euler(0, 0, angle);
            
            return rotationAlignDirection;
        }
    }
}
