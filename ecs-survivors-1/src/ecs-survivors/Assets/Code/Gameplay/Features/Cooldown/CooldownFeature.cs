using Code.Gameplay.Features.Cooldown.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Cooldown
{
    public sealed class CooldownFeature : Feature
    {
        public CooldownFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<CalculateCooldownSystem>());
        }
    }
}