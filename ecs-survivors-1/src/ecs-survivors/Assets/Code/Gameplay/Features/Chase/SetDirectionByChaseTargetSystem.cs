using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Chase
{
    public class SetDirectionByChaseTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _targets;
        private readonly GameContext _game;

        public SetDirectionByChaseTargetSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChaseTargetId, 
                    GameMatcher.WorldPosition));

            _targets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                var target = _game.GetEntityWithId(entity.ChaseTargetId);

                if (!_targets.ContainsEntity(target))
                    continue;

                entity.ReplaceDirection((target.WorldPosition - entity.WorldPosition).normalized);
            }
        }
    }
}