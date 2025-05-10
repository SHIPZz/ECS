using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using DG.Tweening;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnInitialTrailOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IInstantiator _instantiator;

        public SpawnInitialTrailOnHitSystem(GameContext game, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.GotHit,
                    GameMatcher.Alive,
                    GameMatcher.InitialBleedingTrails,
                    GameMatcher.BleedingTrailView
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Vector3 direction = entity.Direction;
        
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotationAlignDirection = Quaternion.Euler(0, 0, angle);

                BleedingTrailData initalTrail = entity.FinalBleedingTrails.PickRandom();
        
                Vector3 startPosition = entity.WorldPosition - direction * entity.LongBleedTrailOffset;
                
                Vector3 endPosition = entity.WorldPosition - direction * entity.BleedTrailOffset;

                var trailView = _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                    initalTrail.Prefab, 
                    startPosition, 
                    rotationAlignDirection,
                    null);
                
                float duration = 0.25f;
                
                trailView.transform.DOMove(endPosition, duration)
                    .SetEase(Ease.InOutQuint)
                    .OnComplete(() => {
                    });
            }
        }
    }
}