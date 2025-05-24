using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public sealed class UpdatePreviousWorldPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entitiesWithWorldPosition;

        public UpdatePreviousWorldPositionSystem(GameContext game)
        {
            _entitiesWithWorldPosition = game.GetGroup(GameMatcher.AllOf(GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entitiesWithWorldPosition)
            {
                if (entity.hasPreviousWorldPosition && entity.PreviousWorldPosition != entity.WorldPosition)
                    entity.ReplacePreviousWorldPosition(entity.WorldPosition);
            }
        }
    }
}