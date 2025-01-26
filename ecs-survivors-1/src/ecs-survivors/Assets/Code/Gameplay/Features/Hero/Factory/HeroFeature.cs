using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Hero.Factory
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeHeroSystem>());
            Add(systems.Create<StopCollectTargetsOnHeroDeadSystem>());
            Add(systems.Create<SetHeroDirectionByInputSystem>());
            Add(systems.Create<AnimateHeroOnMovementSystem>());
            Add(systems.Create<HeroDeathSystem>());
            Add(systems.Create<FinishHeroDeathProcessingSystem>());
        }
    }
}