using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class ScatterOnCollectSystem : ReactiveSystem<GameEntity>
    {
        private const float ScaleDecrease = 0.25f;
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly GameContext _game;

        public ScatterOnCollectSystem(IContext<GameEntity> context,
            IStaticDataService staticDataService,
            GameContext game,
            IArmamentFactory armamentFactory) : base(context)
        {
            _game = game;
            _armamentFactory = armamentFactory;
            _staticDataService = staticDataService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Collected.Added());

        protected override bool Filter(GameEntity entity) => entity.isScatteringArmament
                                                             && entity.isCollected
                                                             && entity.hasScatteringCount
                                                             && entity.hasLastCollectedId;

        protected override void Execute(List<GameEntity> entities)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Scattering, 1);

            ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

            foreach (GameEntity entity in entities)
            {
                GameEntity target = _game.GetEntityWithId(entity.LastCollectedId);

                if (target == null)
                    continue;

                var decreasedScale = new Vector3(entity.Scale.x - ScaleDecrease,
                    entity.Scale.y - ScaleDecrease,
                    entity.Scale.z - ScaleDecrease);

                if (decreasedScale.x <= 0)
                    continue;

                for (int i = 0; i < entity.ScatteringCount; i++)
                {
                    float angle = i * Mathf.PI * projectileSetup.RadialRadius / projectileSetup.ScatteringCount;
                    Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                    
                    _armamentFactory.CreateScatteringBolt(1, target.WorldPosition)
                        .ReplaceDirection(direction)
                        .With(x => x.isMoving = true)
                        .With(x => x.ReplaceScale(decreasedScale))
                        .With(x => x.ProcessedTargetsBuffer.AddRange(entity.ProcessedTargetsBuffer))
                        .With(x => x.isMovingAvailable = true)
                        .With(x => x.isOverflowProcessedTargetsBuffer = true)
                        ;
                }

                entity.isCollected = false;
                entity.RemoveLastCollectedId();
            }
        }
    }
}