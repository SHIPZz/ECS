using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public sealed class StatsFeature : Feature
    {
        public StatsFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<StatChangeSystem>());
            Add(systemses.Create<ApplySpeedFromStatsSystem>());
            Add(systemses.Create<ApplyScaleFromStatsSystem>());
            Add(systemses.Create<ApplyMaxHpFromStatsSystem>());
        }
    }
}