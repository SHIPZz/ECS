using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Statuses.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatusDurationSystem>());
            Add(systems.Create<PeriodicDamageStatusSystem>());
            Add(systems.Create<ApplyStatusesOnTargetsSystem>());
            Add(systems.Create<ApplyFreezeStatusSystem>());
            Add(systems.Create<ApplyMaxHpIncreaseStatusSystem>());
            Add(systems.Create<ApplyScaleStatusSystem>());
            Add(systems.Create<ApplyInvurnableStatusSystem>());
            Add(systems.Create<ApplySpeedUpStatusSystem>());
            Add(systems.Create<ApplyVampirismStatusSystem>());

            Add(systems.Create<CleanupUnappliedStatusLinkedChanges>());
            Add(systems.Create<CleanupUnappliedStatuses>());
        }
    }
}