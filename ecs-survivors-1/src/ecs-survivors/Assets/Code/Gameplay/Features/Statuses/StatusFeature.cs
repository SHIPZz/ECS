using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<StatusDurationSystem>());
            Add(systemses.Create<PeriodicDamageStatusSystem>());
            Add(systemses.Create<ApplyStatusesOnTargetsSystem>());
            Add(systemses.Create<ApplyFreezeStatusSystem>());
            Add(systemses.Create<ApplyMaxHpIncreaseStatusSystem>());
            Add(systemses.Create<ApplyScaleStatusSystem>());
            Add(systemses.Create<ApplyInvurnableStatusSystem>());
            Add(systemses.Create<ApplySpeedUpStatusSystem>());
            Add(systemses.Create<ApplyVampirismStatusSystem>());

            Add(systemses.Create<CleanupUnappliedStatusLinkedChanges>());
            Add(systemses.Create<CleanupUnappliedStatuses>());
        }
    }
}