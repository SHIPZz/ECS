using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Features.Enemies
{
    public sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systems)
        {
            Add(systems.Create<ChaseHeroSystem>());
        }
    }
}