using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class RotateAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public RotateAlongDirectionSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.SpriteRenderer,
                    GameMatcher.RotateAlongDirection,
                    GameMatcher.Transform
                
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _entities)
            {
                if(mover.Direction == Vector3.zero || mover.Direction.sqrMagnitude <= 0.01f)
                    continue;
                
                var angle = Mathf.Atan2(mover.Direction.y, mover.Direction.x) * Mathf.Rad2Deg;
                mover.Transform.rotation = Quaternion.Euler(0,0, angle);
            }
        }

        private float FaceDirection(GameEntity mover) => 
            mover.Direction.x <= 0 ? -1 : 1;
    }
}