using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<DisableMovingAvailableOnDeadSystem>());
            Add(systemses.Create<DirectionalDeltaMoveSystem>());
            Add(systemses.Create<MoveYBySinCurveSystem>());
            Add(systemses.Create<StopMovementOnEndPointReachedSystem>());
            Add(systemses.Create<MarkCollectingAvailableOnEndPointReachedSystem>());
            Add(systemses.Create<CreateAbilityOnEndPointReachedSystem>());
            Add(systemses.Create<OrbitalDeltaMoveSystem>());
            Add(systemses.Create<OrbitCenterFollowTargetSystem>());
            Add(systemses.Create<UpdateTransformPositionSystem>());
            Add(systemses.Create<TurnAlongDirectionSystem>());
            Add(systemses.Create<RotateAlongDirectionSystem>());
        }
    }
}