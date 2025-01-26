using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyHealerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemyHealers;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(32);

        public EnemyHealerSystem(GameContext game, IArmamentFactory armamentFactory,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;

            _enemyHealers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Id,
                    GameMatcher.CooldownUp,
                    GameMatcher.Healer
                ));
        }

        public void Execute()
        {
            foreach (GameEntity enemyHealer in _enemyHealers.GetEntities(_buffer))
            {
                AuraSetup auraSetup = _staticDataService.GetEnemyConfig(EnemyTypeId.Healer).GetAura(AuraTypeId.Heal);

                _armamentFactory
                    .CreateAura(AbilityTypeId.None, auraSetup, enemyHealer.Id)
                    .With(x => x.isHealAura = true);

                enemyHealer.PutOnCooldown();
            }
        }
    }
}