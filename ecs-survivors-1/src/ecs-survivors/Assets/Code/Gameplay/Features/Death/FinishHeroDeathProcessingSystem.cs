using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Death
{
    public class FinishHeroDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(1);

        public FinishHeroDeathProcessingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.DeathProcessing,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _entities.GetEntities(_buffer))
            {
                hero.isDeathProcessing = false;
            }
        }
    }
}