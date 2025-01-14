using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupCollectedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupCollectedSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Collected));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isCollected = false;
            }
        }
    }
}