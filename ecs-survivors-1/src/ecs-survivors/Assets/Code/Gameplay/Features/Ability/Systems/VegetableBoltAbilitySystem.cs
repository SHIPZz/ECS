using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(64);

        public VegetableBoltAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.VegetableBoltAbility, GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                var target = _enemies.AsEnumerable().First();
                
                if(target == null || _enemies.count <= 0)
                    continue;
                
                _armamentFactory.CreateVegetableBolt(1, hero.WorldPosition)
                    .With(x => x.ReplaceDirection((target.WorldPosition - hero.WorldPosition).normalized))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;

                ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityTypeId.VegetableBolt, 1).Cooldown);
            }
        }
    }
}