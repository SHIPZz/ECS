using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class AddNewEnemyOnAppearTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly List<GameEntity> _buffer = new(32);

        public AddNewEnemyOnAppearTimeSystem(GameContext game, EnemySpawnConfig enemySpawnConfig)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnemyAppearTimeUp, 
                    GameMatcher.AddingNewEnemyAvailable, 
                    GameMatcher.EnemyWave));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                WaveData waveData = _enemySpawnConfig.GetWave(entity.EnemyWave);
                
                entity.EnemySpawnIds.AddRange(waveData.EnemiesToAppear);
                entity.isAddingNewEnemyAvailable = false;
            }
        }
    }
}