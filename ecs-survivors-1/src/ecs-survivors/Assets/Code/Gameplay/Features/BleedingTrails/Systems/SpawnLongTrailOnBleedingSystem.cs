using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Factory;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnLongTrailOnBleedingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IBleedingTrailEntityFactory _bleedingTrailEntityFactory;

        public SpawnLongTrailOnBleedingSystem(GameContext game, IBleedingTrailEntityFactory bleedingTrailEntityFactory)
        {
            _bleedingTrailEntityFactory = bleedingTrailEntityFactory;
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.Bleeding,
                    GameMatcher.BleedingAvailable,
                    GameMatcher.BleedingTrailSpawnAvailable,
                    GameMatcher.BleedingTrails
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (BleedingTrailData bleedingTrailData in entity.BleedSpawnList)
            {
                Vector3 direction = entity.Direction;

                Vector3 spawnPosition = entity.WorldPosition + direction * entity.LongBleedTrailOffset;

                _bleedingTrailEntityFactory.Create(spawnPosition, Quaternion.identity, null, bleedingTrailData)
                    .With(x => x.ReplaceDirection(direction))
                    ;

                entity.ReplaceLastBleedTrailSpawnTime(Time.time);
            }
        }
    }
}