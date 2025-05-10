using System.Collections.Generic;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.KickingBacks.Systems
{
    public class CleanupKickingBackSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private List<GameEntity> _buffer = new(2);

        public CleanupKickingBackSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.Speed,
                    GameMatcher.KickingBackCooldownUp,
                    GameMatcher.KickingBacking));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isKickingBackCooldownUp = true;
                entity.isKickingBacking = false;
                entity.BaseStats[Stats.Speed] = entity.InitialSpeed;
            }
        }
    }
}