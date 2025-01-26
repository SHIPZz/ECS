using Code.Gameplay.Features.Ability.Systems;
using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Statuses.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeTimerSpawnSystem>());
            Add(systems.Create<EnemySpawnSystem>());
            Add(systems.Create<ChaseHeroSystem>());
            Add(systems.Create<EnemyHealerSystem>());
            Add(systems.Create<EnemySpeedUpSystem>());
            Add(systems.Create<ChaseEnemySystem>());
            Add(systems.Create<StopEnemyMovementOnHeroDeathSystem>());
            Add(systems.Create<EnemyDeathSystem>());
            Add(systems.Create<SpeedUpOnEnemyDeadAbilitySystem>());
            Add(systems.Create<EnemyDropLootSystem>());
            Add(systems.Create<FinishEnemyDeathProcessingSystem>());
        }
    }
}