using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Cooldown.Systems
{
    public class CalculateCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public CalculateCooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceCooldownLeft(entity.CooldownLeft - _timeService.DeltaTime);
                entity.isCooldownUp = false;

                if (entity.CooldownLeft <= 0)
                {
                    entity.ReplaceCooldownLeft(entity.Cooldown);
                    entity.isCooldownUp = true;
                }
            }
        }
    }
}