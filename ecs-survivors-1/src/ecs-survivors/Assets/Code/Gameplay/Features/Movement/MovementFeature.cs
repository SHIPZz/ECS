using Code.Gameplay.Features.Movement.Systems;

namespace Code.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
        }
    }
}