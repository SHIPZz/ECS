using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpeedUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemySpeedUps;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(32);

        public EnemySpeedUpSystem(GameContext game, IArmamentFactory armamentFactory,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;

            _enemySpeedUps = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Id,
                    GameMatcher.CooldownUp,
                    GameMatcher.Buffer
                ));
        }

        public void Execute()
        {
            foreach (GameEntity enemySpeedUp in _enemySpeedUps.GetEntities(_buffer))
            {
                AuraSetup auraSetup = _staticDataService.GetEnemyConfig(EnemyTypeId.Buffer).GetAura(AuraTypeId.SpeedUp);

                _armamentFactory.CreateAura(AbilityTypeId.None, auraSetup, enemySpeedUp.Id);
                
                enemySpeedUp.PutOnCooldown();
            }
        }
    }
}