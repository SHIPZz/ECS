﻿using Code.Common.Extensions;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CastForPullableSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _looters;
        private readonly IPhysicsService _physicsService;
        private readonly GameEntity[] _hitBuffer = new GameEntity[128];

        public CastForPullableSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;

            _looters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.PickupRadius
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _looters)
            {
                for (int i = 0; i < LootInRadius(entity); i++)
                {
                    if (_hitBuffer[i].isPullable)
                    {
                        _hitBuffer[i].isPullable = false;
                        _hitBuffer[i].isPulling = true;
                    }
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBuffer.Length; i++)
            {
                _hitBuffer[i] = null;
            }
        }

        private int LootInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.PickupRadius,
                CollisionLayer.Collectable.AsMask(),
                _hitBuffer);
        }
    }
}