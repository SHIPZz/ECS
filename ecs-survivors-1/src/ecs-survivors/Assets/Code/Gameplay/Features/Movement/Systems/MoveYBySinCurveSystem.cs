using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MoveYBySinCurveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public MoveYBySinCurveSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.AnimationDuration,
                    GameMatcher.ElapsedTime,
                    GameMatcher.StartHeight,
                    GameMatcher.Moving,
                    GameMatcher.UpdateHeightBySinCurve
                ).NoneOf(GameMatcher.HeightUpdated));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                var position = entity.WorldPosition;
                var animationDuration = entity.AnimationDuration;
                var elapsedTime = entity.ElapsedTime;

                elapsedTime += Time.deltaTime;

                if (elapsedTime >= animationDuration)
                {
                    entity.isHeightUpdated = true;
                    continue;
                }
                
                var normalizedTime = (elapsedTime % animationDuration) / animationDuration;
                var yOffset = Mathf.Sin(normalizedTime * Mathf.PI) * 2f; 
                
                entity.ReplaceWorldPosition(new Vector3(
                    position.x,
                    entity.StartHeight + yOffset,
                    position.z
                ));

                entity.ReplaceElapsedTime(elapsedTime);
            }
        }
    }
}