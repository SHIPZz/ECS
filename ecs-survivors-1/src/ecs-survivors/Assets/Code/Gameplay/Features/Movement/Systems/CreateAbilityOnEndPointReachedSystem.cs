using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Factory;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class CreateAbilityOnEndPointReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IAbilityFactory _abilityFactory;
        private List<GameEntity> _buffer = new(32);

        public CreateAbilityOnEndPointReachedSystem(GameContext game,
            IAbilityFactory abilityFactory)
        {
            _abilityFactory = abilityFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EndPointReached,
                    GameMatcher.Id,
                    GameMatcher.AbilityHolder
                    ).NoneOf(GameMatcher.Applied));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (AbilityTypeId abilityTypeId in entity.AbilityHolder)
            {
                _abilityFactory.CreateAbility(abilityTypeId, 1)
                    .With(x => x.AddProducerId(entity.Id));

                entity.isApplied = true;
            }
        }
    }
}