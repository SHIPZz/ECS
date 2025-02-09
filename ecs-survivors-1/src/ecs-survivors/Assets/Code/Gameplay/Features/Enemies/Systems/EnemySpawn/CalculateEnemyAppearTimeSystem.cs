using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class CalculateEnemyAppearTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(5);

        public CalculateEnemyAppearTimeSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnemyAppearTime, 
                    GameMatcher.EnemyAppearTimeLeft
                    ).NoneOf(GameMatcher.EnemyAppearTimeUp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceEnemyAppearTimeLeft(entity.EnemyAppearTimeLeft - _timeService.DeltaTime);

                if (entity.EnemyAppearTimeLeft <= 0)
                {
                    entity.isEnemyAppearTimeUp = true;
                    entity.ReplaceEnemyAppearTimeLeft(entity.EnemyAppearTime);
                }
            }
        }
    }
}