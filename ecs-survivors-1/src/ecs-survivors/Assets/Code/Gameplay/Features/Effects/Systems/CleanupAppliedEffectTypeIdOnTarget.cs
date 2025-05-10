using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class CleanupAppliedEffectTypeIdOnTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupAppliedEffectTypeIdOnTarget(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AppliedEffectTypeIdsOnTarget));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.AppliedEffectTypeIdsOnTarget.Clear();
            }
        }
    }
}