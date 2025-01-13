using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class StopCollectTargetsOnHeroDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(128);

        public StopCollectTargetsOnHeroDeadSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Dead));

            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetsBuffer,
                GameMatcher.CollectingAvailable,
                GameMatcher.CollectTargetsInterval,
                GameMatcher.CollectTargetsTimer
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isCollectingAvailable = false;
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
            }
        }
    }
}