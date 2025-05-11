using System.Collections.Generic;
using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.KickingBacks.Systems
{
    public class KickBackOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private List<GameEntity> _buffer = new(12);

        public KickBackOnHitSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Direction,
                    GameMatcher.Speed,
                    GameMatcher.KickingBackForce,
                    GameMatcher.KickingBackAvailable,
                    GameMatcher.GotHit
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isKickingBacking = true;
                entity.BaseStats[Stats.Speed] = entity.KickingBackForce;
                entity.ReplaceDirection(-entity.Direction);
            }
        }
    }
}