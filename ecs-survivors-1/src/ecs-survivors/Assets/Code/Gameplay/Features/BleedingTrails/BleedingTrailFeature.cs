using Code.Gameplay.Features.BleedingTrails.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.BleedingTrails
{
    public sealed class BleedingTrailFeature : Feature
    {
        public BleedingTrailFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdatePreviousWorldPositionSystem>());
            Add(systems.Create<DetermineBleedTrailSpawnRequestSystem>());
            Add(systems.Create<SpawnTrailOnRequestSystem>());
            Add(systems.Create<SetTrailSpawningAvailabilityOnLastSpawnTimeSystem>());
        }
    }
}