﻿using Entitas;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetBuffersSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.TargetsBuffer));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.TargetsBuffer.Clear();
            }
        }
    }
}