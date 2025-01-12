using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Features.Hero
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeHeroSystem>());
            Add(systems.Create<SetHeroDirectionByInputSystem>());
            Add(systems.Create<AnimateHeroOnMovementSystem>());
            Add(systems.Create<HeroDeathSystem>());
            Add(systems.Create<FinishHeroDeathProcessingSystem>());
        }
    }
}