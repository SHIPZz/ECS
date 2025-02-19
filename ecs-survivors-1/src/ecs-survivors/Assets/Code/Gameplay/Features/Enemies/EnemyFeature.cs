using Code.Gameplay.Features.Abilities.Systems;
using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Enemies.Systems.EnemySpawn;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<InitializeEnemyWaveSpawnSystem>());
            Add(systemses.Create<UpdateEnemyWaveOnCooldownSystem>());
            Add(systemses.Create<CalculateEnemyWaveSpawnIntervalSystem>());
            Add(systemses.Create<CalculateEnemyAppearTimeSystem>());
            Add(systemses.Create<AddNewEnemyOnAppearTimeSystem>());
            Add(systemses.Create<EnemySpawnSystem>());
            Add(systemses.Create<ChaseHeroSystem>());
            Add(systemses.Create<EnemyHealerSystem>());
            Add(systemses.Create<EnemySpeedUpSystem>());
            Add(systemses.Create<ChaseEnemySystem>());
            Add(systemses.Create<StopEnemyMovementOnHeroDeathSystem>());
            Add(systemses.Create<EnemyDeathSystem>());
            Add(systemses.Create<SpeedUpOnEnemyDeadAbilitySystem>());
            Add(systemses.Create<EnemyDropLootSystem>());
            Add(systemses.Create<FinishEnemyDeathProcessingSystem>());
            Add(systemses.Create<CountEnemyDeadSystem>());
            Add(systemses.Create<FinalizeEnemySpawnAvailabilitySystem>());
            Add(systemses.Create<FinalizeEnemyAppearTimeSystem>());
        }
    }
}