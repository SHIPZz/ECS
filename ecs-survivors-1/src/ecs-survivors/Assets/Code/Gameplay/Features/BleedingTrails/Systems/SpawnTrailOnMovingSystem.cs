using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnTrailOnMovingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IInstantiator _instantiator;
        private float _lastTrailSpawnTime;

        public SpawnTrailOnMovingSystem(GameContext game, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.KickingBacking,
                    GameMatcher.MovingBleedingTrails
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if(Time.time < _lastTrailSpawnTime + entity.TrailSpawnInterval)
                    return;
                
                Vector3 direction = entity.Direction;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotationAlignDirection = Quaternion.Euler(0, 0, angle);

                BleedingTrailData BleedingTrailData = entity.MovingBleedingTrails.PickRandom();
                
                BleedingTrailData trailData = entity.InitialBleedingTrails.PickRandom();

                float offsetDistance = 0.2f;
                Vector3 spawnPosition = entity.WorldPosition - direction * offsetDistance;

                _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                    BleedingTrailData.Prefab,
                    spawnPosition,
                    rotationAlignDirection,
                    null);
                
                _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                    trailData.Prefab,
                    spawnPosition,
                    rotationAlignDirection,
                    null);
                
                _lastTrailSpawnTime = Time.time;
            }
        }
    }
}