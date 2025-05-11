using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SpawnTrailOnKickingBackSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IInstantiator _instantiator;

        public SpawnTrailOnKickingBackSystem(GameContext game, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive,
                    GameMatcher.KickingBacking,
                    GameMatcher.BleedingTrails
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (Time.time < entity.LastBleedTrailSpawnTime + entity.BleedTrailSpawnInterval)
                    return;

                Vector3 direction = entity.Direction;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotationAlignDirection = Quaternion.Euler(0, 0, angle);

                BleedingTrailData longTrailData = null;
                BleedingTrailData splashData = null;

                if (entity.Speed >= entity.LongBleedTrailSpeed)
                {
                    longTrailData = entity.BleedingTrails[BleedingTrailTypeId.Long].PickRandom();
                    splashData = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();
                }
                else
                {
                    splashData = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();
                }

                Vector3 spawnPosition = entity.WorldPosition + direction * entity.LongBleedTrailOffset;

                if (longTrailData != null)
                    _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                        longTrailData.Prefab,
                        spawnPosition,
                        rotationAlignDirection,
                        null);

                _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                    splashData.Prefab,
                    spawnPosition,
                    rotationAlignDirection,
                    null);

                entity.ReplaceLastBleedTrailSpawnTime(Time.time);
            }
        }
    }
}