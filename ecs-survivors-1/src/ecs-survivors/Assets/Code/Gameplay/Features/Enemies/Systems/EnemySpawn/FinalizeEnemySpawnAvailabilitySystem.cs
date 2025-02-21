using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class FinalizeEnemySpawnAvailabilitySystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public FinalizeEnemySpawnAvailabilitySystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.EnemyWave, GameMatcher.EnemySpawnAvailable));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isEnemySpawnAvailable = false;
            }
        }
    }
}