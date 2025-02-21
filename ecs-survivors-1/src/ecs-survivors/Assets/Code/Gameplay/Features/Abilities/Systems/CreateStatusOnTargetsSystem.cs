using System.Collections.Generic;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CreateStatusOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(32);
        private readonly IStatusApplier _statusApplier;

        public CreateStatusOnTargetsSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.StatusSetups,
                    GameMatcher.CooldownUp,
                    GameMatcher.StatusCreator
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (var targetId in entity.TargetsBuffer)
            {
                foreach (var statusSetup in entity.StatusSetups)
                {
                    // _statusApplier.ApplyStatus(statusSetup, entity.Id, targetId);
                }

                entity.PutOnCooldown();
            }
        }
    }
}