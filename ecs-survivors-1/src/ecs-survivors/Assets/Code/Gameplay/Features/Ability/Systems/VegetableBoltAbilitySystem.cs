using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public VegetableBoltAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.VegetableBoltAbility, GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity entity in _entities)
            {
                var target = _enemies.AsEnumerable().First();
                
                if(target == null || _enemies.count <= 0)
                    continue;
                
                _armamentFactory.CreateVegetableBolt(1, hero.WorldPosition)
                    .With(x => x.ReplaceDirection((target.WorldPosition - hero.WorldPosition).normalized))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;
            }
        }
    }
}