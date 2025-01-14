using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class ScatterOnHitSystem : IExecuteSystem
    {
        private const float ScaleDecrease = 0.25f;
        
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _armaments;
        private readonly IGroup<GameEntity> _targets;

        public ScatterOnHitSystem(
            IStaticDataService staticDataService,
            GameContext game,
            IArmamentFactory armamentFactory)
        {
            _game = game;
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ScatteringArmament,
                    GameMatcher.Scale,
                    GameMatcher.LastCollectedId,
                    GameMatcher.Collected
                    ));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.WorldPosition, GameMatcher.Id));
            
            _armamentFactory = armamentFactory;
            _staticDataService = staticDataService;
        }

        public void Execute()
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Scattering, 1);

            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            foreach (GameEntity armament in _armaments)
            {
                GameEntity target = _game.GetEntityWithId(armament.LastCollectedId);

                if (!_targets.ContainsEntity(target))
                    continue;

                var decreasedScale = new Vector3(armament.Scale.x - ScaleDecrease,
                    armament.Scale.y - ScaleDecrease,
                    armament.Scale.z - ScaleDecrease);

                if (decreasedScale.x <= 0.1f)
                {
                    armament.isProcessed = true;
                    continue;
                }

                for (int i = 0; i < armament.ScatteringCount; i++)
                {
                    float angle = i * Mathf.PI * projectileSetup.RadialRadius / projectileSetup.ScatteringCount;
                    Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                    
                    _armamentFactory.CreateScatteringBolt(1, target.WorldPosition)
                        .ReplaceDirection(direction)
                        .With(x => x.isMoving = true)
                        .With(x => x.ReplaceScale(decreasedScale))
                        .With(x => x.ProcessedTargetsBuffer.Add(armament.LastCollectedId))
                        .With(x => x.isMovingAvailable = true)
                        .With(x => x.isOverflowProcessedTargetsBuffer = true)
                        ;
                }
            }
        }
    }
}