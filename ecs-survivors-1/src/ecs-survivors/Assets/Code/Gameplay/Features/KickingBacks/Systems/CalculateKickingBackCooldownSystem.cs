using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.KickingBacks.Systems
{
    public class CalculateKickingBackCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(16);

        public CalculateKickingBackCooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.KickingBackCooldown,
                    GameMatcher.KickingBackCooldownLeft
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceKickingBackCooldownLeft(entity.KickingBackCooldownLeft - _timeService.DeltaTime);
                entity.isCooldownUp = false;

                if (entity.KickingBackCooldownLeft <= 0)
                {
                    entity.isKickingBackCooldownUp = true;
                    entity.RemoveKickingBackCooldownLeft();
                }
            }
        }
    }
}