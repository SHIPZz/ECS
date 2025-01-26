using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Movement.Systems;

namespace Code.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DisableMovingAvailableOnDeadSystem>());
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<OrbitalDeltaMoveSystem>());
            Add(systems.Create<OrbitCenterFollowTargetSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<RotateAlongDirectionSystem>());
        }
    }
}