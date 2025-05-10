using Code.Gameplay.Features.BleedingTrails.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.BleedingTrails
{
    public sealed class BleedingTrailFeature : Feature
    {
        public BleedingTrailFeature(ISystemFactory systems)
        {
            Add(systems.Create<PutOnBleedingTrailSpawnCooldownOnHitSystem>());
            Add(systems.Create<CalculateBleedingTrailSpawnCooldownSystem>());
            Add(systems.Create<SpawnInitialTrailOnHitSystem>());
            Add(systems.Create<SpawnTrailOnKickingBackSystem>());
        }
    }
}