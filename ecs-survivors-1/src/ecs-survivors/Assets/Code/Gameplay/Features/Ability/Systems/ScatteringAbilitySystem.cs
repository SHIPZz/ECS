using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament;
using Code.Gameplay.Features.Cooldown;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class ScatteringAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(32);

        public ScatteringAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
            _abilities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ScatteringAbility, GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                GameEntity target = _enemies.AsEnumerable().First();
                
                if(target == null || _enemies.count <= 0)
                    continue;
                
                _armamentFactory.CreateScatteringBolt(1, hero.WorldPosition)
                    .With(x => x.AddChaseTargetId(target.Id))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;

                ability.PutOnCooldown();
            }
        }
    }
}