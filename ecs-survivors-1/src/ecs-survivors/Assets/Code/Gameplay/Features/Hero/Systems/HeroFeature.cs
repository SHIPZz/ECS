using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Features.Hero.Systems
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetHeroDirectionByInputSystem>());
            Add(systems.Create<AnimateHeroOnMovementSystem>());
        }
    }
}