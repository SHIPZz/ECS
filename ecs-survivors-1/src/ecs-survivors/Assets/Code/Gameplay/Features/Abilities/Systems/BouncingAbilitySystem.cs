using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Common;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BouncingAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(128);
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGetClosestEntityService _getClosestEntityService;

        public BouncingAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IGetClosestEntityService getClosestEntityService)
        {
            _getClosestEntityService = getClosestEntityService;
            _armamentFactory = armamentFactory;
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy, 
                GameMatcher.WorldPosition,
                GameMatcher.Alive));
            
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.WorldPosition));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BouncingAbility,
                    GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                GameEntity target =_getClosestEntityService.GetClosestEntity(hero, _enemies);

                _armamentFactory.CreateBouncingBolt(1, hero.WorldPosition)
                    .With(x => x.AddFollowTargetId(target.Id))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true);

                ability.PutOnCooldown();
            }
        }
    }
}