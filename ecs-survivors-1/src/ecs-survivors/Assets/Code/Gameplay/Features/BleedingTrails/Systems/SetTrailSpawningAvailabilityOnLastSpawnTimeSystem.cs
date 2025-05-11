using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SetTrailSpawningAvailabilityOnLastSpawnTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetTrailSpawningAvailabilityOnLastSpawnTimeSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LastBleedTrailSpawnTime,
                    GameMatcher.BleedTrailSpawnInterval));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isBleedingTrailSpawnAvailable = Time.time > entity.LastBleedTrailSpawnTime + entity.BleedTrailSpawnInterval;
            }
        }
    }
}