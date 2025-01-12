﻿using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection
{
    public class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public CollectTargetsIntervalSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CollectTargetsInterval,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.CollectTargetsTimer
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _timeService.DeltaTime);

                if (entity.CollectTargetsTimer <= 0)
                {
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
                    entity.isReadyToCollectTargets = true;
                }
            }
        }
    }
}