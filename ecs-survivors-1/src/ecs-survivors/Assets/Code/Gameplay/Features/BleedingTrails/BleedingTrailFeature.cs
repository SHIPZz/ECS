using Code.Gameplay.Features.BleedingTrails.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.BleedingTrails
{
    public sealed class BleedingTrailFeature : Feature
    {
        public BleedingTrailFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetBleedingStoppedOnKickingBackStoppedSystem>()); //you'll probably use another condition
            Add(systems.Create<SetTrailSpawningAvailabilityOnLastSpawnTimeSystem>());
            Add(systems.Create<SelectSpawnBleedingTrailsSystem>());
            
            Add(systems.Create<SpawnSingleSplashOnBleedingStartedSystem>());
            Add(systems.Create<SpawnLongTrailOnBleedingSystem>());

            Add(systems.Create<CleanupBleedingSystem>());
            Add(systems.Create<CleanupBleedTrailSpawnListSystem>());
        }
    }
}