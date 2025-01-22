using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public sealed class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatChangeSystem>());
            Add(systems.Create<ApplySpeedFromStatsSystem>());
            Add(systems.Create<ApplyScaleFromStatsSystem>());
            Add(systems.Create<ApplyMaxHpFromStatsSystem>());
        }
    }
}