using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class CalculateEnemyWaveSpawnIntervalSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(32);

        public CalculateEnemyWaveSpawnIntervalSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnemyWave, GameMatcher.EnemySpawnInterval)
                .NoneOf(GameMatcher.EnemySpawnAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceEnemySpawnInterval(entity.EnemySpawnInterval - _timeService.DeltaTime);

                if (entity.EnemySpawnInterval <= 0)
                {
                    entity.isEnemySpawnAvailable = true;
                    entity.ReplaceEnemySpawnInterval(entity.EnemySpawnMaxInterval);
                }
            }
        }
    }
}