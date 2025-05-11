using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class CleanupBleedingSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupBleedingSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BleedingRequested,
                GameMatcher.BleedingAvailable
                    ));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isBleedingRequested = false;
            }
        }
    }
}