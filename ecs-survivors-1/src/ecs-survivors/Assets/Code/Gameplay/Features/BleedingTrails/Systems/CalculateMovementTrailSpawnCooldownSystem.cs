using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class CalculateBleedingTrailSpawnCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(10);

        public CalculateBleedingTrailSpawnCooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BleedingTrailSpawnCooldown,
                    GameMatcher.Alive,
                    GameMatcher.BleedingTrailSpawnCooldownLeft)
                .NoneOf(GameMatcher.BleedingTrailSpawnCooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.bleedingTrailSpawnCooldownLeft.Value -= _timeService.DeltaTime;

                if (entity.BleedingTrailSpawnCooldownLeft <= 0)
                {
                    entity.ReplaceBleedingTrailSpawnCooldownLeft(entity.BleedingTrailSpawnCooldown);
                    entity.isBleedingTrailSpawnCooldownUp = true;
                }
            }
        }
    }
}