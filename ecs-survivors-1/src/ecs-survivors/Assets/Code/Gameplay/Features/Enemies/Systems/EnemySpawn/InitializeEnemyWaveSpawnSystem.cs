using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldown;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class InitializeEnemyWaveSpawnSystem : IInitializeSystem
    {
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly IIdentifierService _identifierService;

        public InitializeEnemyWaveSpawnSystem(EnemySpawnConfig enemySpawnConfig, IIdentifierService identifierService)
        {
            _identifierService = identifierService;
            _enemySpawnConfig = enemySpawnConfig;
        }

        public void Initialize()
        {
            int stage = 1;
            
            WaveData waveData = _enemySpawnConfig.GetWave(stage);

            InitEnemyDeadCount();

            CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddEnemyWave(stage)
                .AddEnemyAppearTime(waveData.EnemyAppearTime)
                .AddEnemyAppearTimeLeft(waveData.EnemyAppearTime)
                .AddCooldown(waveData.Cooldown)
                .AddEnemySpawnIds(waveData.Enemies.ToList())
                .AddEnemySpawnCount(waveData.Count)
                .AddEnemySpawnMaxInterval(waveData.SpawnInterval)
                .AddEnemySpawnInterval(waveData.SpawnInterval)
                .PutOnCooldown()
                .With(x=> x.isEnemySpawnAvailable = true)
                .With(x=> x.isAddingNewEnemyAvailable = true)
                ;
        }

        private void InitEnemyDeadCount()
        {
            CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEnemyDeadCount(0)
                ;
        }
    }
}