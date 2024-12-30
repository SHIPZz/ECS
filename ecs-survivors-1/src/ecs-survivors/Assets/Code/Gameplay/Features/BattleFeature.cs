using Code.Gameplay.Cameras;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;

namespace Code.Gameplay.Features
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());
        }
    }
}