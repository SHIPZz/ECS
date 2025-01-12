using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class DestructOnZeroHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public DestructOnZeroHpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CurrentHp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.CurrentHp <= 0)
                    entity.isDestructed = true;
            }
        }
    }
}