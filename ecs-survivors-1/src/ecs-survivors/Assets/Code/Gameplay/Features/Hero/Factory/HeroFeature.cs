using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero.Factory
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory system)
        {
            Add(system.Create<InitializeHeroSystem>());
            Add(system.Create<StopCollectTargetsOnHeroDeadSystem>());
            Add(system.Create<SetHeroDirectionByInputSystem>());
            Add(system.Create<AnimateHeroOnMovementSystem>());
            Add(system.Create<HeroDeathSystem>());
            Add(system.Create<FinishHeroDeathProcessingSystem>());
        }
    }
}