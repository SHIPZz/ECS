using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupGotHitEntities : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(10);

        public CleanupGotHitEntities(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.GotHit));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isGotHit = false;
            }
        }
    }
}