using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    public class ChaseHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public ChaseHeroSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);

            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            foreach (GameEntity hero in _heroes)
            {
                if (hero.isDestructed)
                {
                    enemy.ReplaceDirection(Vector3.zero);
                    enemy.isMoving = false;
                    continue;
                }
                
                enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
                enemy.isMoving = true;
            }
        }
    }
}