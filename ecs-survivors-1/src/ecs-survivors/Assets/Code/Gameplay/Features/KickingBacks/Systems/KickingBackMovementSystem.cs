using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.CharacterStats;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.KickingBacks.Systems
{
    public class KickingBackMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(32);

        public KickingBackMovementSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.KickingBackForce, 
                    GameMatcher.KickingBacking, 
                    GameMatcher.KickingBackAvailable, 
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            float deltaTime = _timeService.DeltaTime;

            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                float force = entity.BaseStats[Stats.Speed];

                float newForce = Mathf.MoveTowards(force, 0f, entity.KickingBackDamping * deltaTime);

                if (newForce <= entity.KickingBackStopForce)
                {
                    entity.isKickingBacking = false;
                }
                else
                {
                    entity.BaseStats[Stats.Speed] = newForce;
                }
            }
        }
    }
}