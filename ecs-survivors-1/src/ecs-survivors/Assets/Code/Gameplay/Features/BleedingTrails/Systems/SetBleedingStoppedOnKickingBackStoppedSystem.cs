using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SetBleedingStoppedOnKickingBackStoppedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public SetBleedingStoppedOnKickingBackStoppedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Bleeding, GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (!entity.isKickingBacking)
                    entity.isBleeding = false;
            }
        }
    }
}