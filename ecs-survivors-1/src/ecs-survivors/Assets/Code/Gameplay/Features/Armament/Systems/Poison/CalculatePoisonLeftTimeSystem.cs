using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Armament.Systems.Poison
{
    public class CalculatePoisonLeftTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(128);

        public CalculatePoisonLeftTimeSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisonTime,
                    GameMatcher.PoisonTimeLeft
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplacePoisonTimeLeft(entity.PoisonTimeLeft - _timeService.DeltaTime);

                if (entity.PoisonTimeLeft <= 0)
                {
                    entity.isPoisonTimeUp = true;
                    entity.RemovePoisonTimeLeft();
                }
            }
        }
    }
}