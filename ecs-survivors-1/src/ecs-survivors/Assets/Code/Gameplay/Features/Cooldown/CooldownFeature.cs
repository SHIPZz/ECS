using Code.Gameplay.Features.Cooldown.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Cooldown
{
    public sealed class CooldownFeature : Feature
    {
        public CooldownFeature(ISystemFactory systems)
        {
            Add(systems.Create<CalculateCooldownSystem>());
        }
    }
}