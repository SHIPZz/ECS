﻿using Entitas;

namespace Code.Gameplay.Features.Scale.Systems
{
    public class UpdateScaleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateScaleSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ScaleTransform,
                    GameMatcher.Scale
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ScaleTransform.localScale = entity.Scale;
            }
        }
    }
}