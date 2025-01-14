using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Armament.Systems.Poison
{
    public class CleanTargetPoisonedOnPoisonTimeUp : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanTargetPoisonedOnPoisonTimeUp(GameContext game)
        {
            _group = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Poisoned,
                    GameMatcher.PoisonTimeUp));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isPoisoned = false;
            }
        }
    }
}