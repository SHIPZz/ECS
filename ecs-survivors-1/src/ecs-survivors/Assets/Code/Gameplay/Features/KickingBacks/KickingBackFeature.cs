using Code.Gameplay.Features.KickingBacks.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.KickingBacks
{
    public sealed class KickingBackFeature : Feature
    {
        public KickingBackFeature(ISystemFactory systems)
        {
            Add(systems.Create<KickBackOnHitSystem>());
            Add(systems.Create<KickingBackMovementSystem>());
            Add(systems.Create<CleanupKickingBackSystem>());
        }
    }
}