using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Lifetime
{
    public sealed class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkIsAliveSystem>());
        }
    }
    
}