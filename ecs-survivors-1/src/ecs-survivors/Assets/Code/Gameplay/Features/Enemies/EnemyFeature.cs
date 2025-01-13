using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Enemies
{
    public sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeTimerSpawnSystem>());
            Add(systems.Create<EnemySpawnSystem>());
            Add(systems.Create<ChaseHeroSystem>());
            Add(systems.Create<StopEnemyMovementOnHeroDeathSystem>());
            Add(systems.Create<EnemyDeathSystem>());
            Add(systems.Create<FinishEnemyDeathProcessingSystem>());
        }
    }
}