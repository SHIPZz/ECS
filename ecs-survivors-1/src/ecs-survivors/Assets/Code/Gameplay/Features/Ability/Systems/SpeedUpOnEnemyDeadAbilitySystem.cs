using System.Collections.Generic;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class SpeedUpOnEnemyDeadAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _deadEnemies;
        private readonly IStatusApplier _statusApplier;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(32);

        public SpeedUpOnEnemyDeadAbilitySystem(GameContext game, IStatusApplier statusApplier,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _statusApplier = statusApplier;
            
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
            
            _deadEnemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Dead,
                GameMatcher.DeathProcessing));

            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SpeedUpAbility,
                    GameMatcher.CooldownUp
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                if (_deadEnemies.count <= 0)
                    continue;

                AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.SpeedUp, 1);

                foreach (StatusSetup statusSetup in abilityLevel.StatusSetups)
                {
                    _statusApplier.ApplyStatus(statusSetup, hero.Id, hero.Id);
                }

                ability.PutOnCooldown();
            }
        }
    }
}