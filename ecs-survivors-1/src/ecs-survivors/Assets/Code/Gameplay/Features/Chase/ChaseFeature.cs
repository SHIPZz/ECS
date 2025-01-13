using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Chase
{
    public sealed class ChaseFeature : Feature
    {
        public ChaseFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetDirectionByChaseTargetSystem>());
        }
    }
}