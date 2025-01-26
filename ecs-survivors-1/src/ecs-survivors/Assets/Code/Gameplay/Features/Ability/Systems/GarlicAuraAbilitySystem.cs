﻿using System.Collections.Generic;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament.Factory;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(64);

        public GarlicAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.GarlicAuraAbility)
                .NoneOf(GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                ability.isActive = true;
                _armamentFactory.CreateEffectAura( AbilityTypeId.GarlicAura,hero.Id, 1)
                    ;
            }
        }
    }
}