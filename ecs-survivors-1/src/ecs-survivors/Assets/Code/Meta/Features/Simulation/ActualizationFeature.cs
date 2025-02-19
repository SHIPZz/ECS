using Code.Common;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Achievements;

namespace Code.Meta.Features.Simulation
{
    public sealed class ActualizationFeature : Feature
    {
        public ActualizationFeature(ISystemFactory systems)
        {
            Add(systems.Create<SimulationFeature>());
            Add(systems.Create<AchievementFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}