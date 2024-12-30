using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public TurnAlongDirectionSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TurnAlongDirection,
                    GameMatcher.Direction,
                    GameMatcher.SpriteRenderer,
                    GameMatcher.Transform
                
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _entities)
            {
                var scale = Mathf.Abs(mover.SpriteRenderer.transform.localScale.x);
                mover.SpriteRenderer.transform.SetScaleX(scale * FaceDirection(mover));
            }
        }

        private float FaceDirection(GameEntity mover) => 
            mover.Direction.x <= 0 ? -1 : 1;
    }
}