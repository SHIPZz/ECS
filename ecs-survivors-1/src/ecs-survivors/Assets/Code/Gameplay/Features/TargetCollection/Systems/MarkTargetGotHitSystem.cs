using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class MarkTargetGotHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly GameContext _game;

        public MarkTargetGotHitSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (int targetId in entity.TargetsBuffer)
            {
               GameEntity target = _game.GetEntityWithId(targetId);
                
               target.isGotHit = true;
            }
        }
    }
}