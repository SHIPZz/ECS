using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldown;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class UpdateEnemyWaveOnCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemyWaves;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly EnemySpawnConfig _enemySpawnConfig;

        public UpdateEnemyWaveOnCooldownSystem(GameContext game, EnemySpawnConfig enemySpawnConfig)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _enemyWaves = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnemyWave,
                    GameMatcher.CooldownUp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity enemyWave in _enemyWaves.GetEntities(_buffer))
            {
                int nextStage = enemyWave.EnemyWave + 1;

                WaveData waveData = _enemySpawnConfig.GetWave(nextStage);

                enemyWave
                    .ReplaceEnemyWave(nextStage)
                    .ReplaceEnemyAppearTime(waveData.EnemyAppearTime)
                    .ReplaceEnemyAppearTimeLeft(waveData.EnemyAppearTime)
                    .ReplaceCooldown(waveData.Cooldown)
                    .ReplaceEnemySpawnIds(waveData.Enemies.ToList())
                    .ReplaceEnemySpawnCount(waveData.Count)
                    .ReplaceEnemySpawnMaxInterval(waveData.SpawnInterval)
                    .ReplaceEnemySpawnInterval(waveData.SpawnInterval)
                    .PutOnCooldown()
                    .With(x=> x.isAddingNewEnemyAvailable = true)
                    .With(x=> x.isEnemySpawnAvailable = true)
                    ;
            }
        }
    }
}