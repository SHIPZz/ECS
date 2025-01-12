using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;

namespace Code.Gameplay.Features.Enemies
{
    public sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeTimerSpawnSystem>());
            Add(systems.Create<EnemySpawnSystem>());
            Add(systems.Create<ChaseHeroSystem>());
            Add(systems.Create<StopMovementOnHeroDeathSystem>());
        }
    }
}