using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class FinishEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);
        
        public FinishEnemyDeathProcessingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.DeathProcessing,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _entities.GetEntities(_buffer))
            {
                enemy.isDeathProcessing = false;
            }
        }
    }
}