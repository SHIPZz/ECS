using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class SelectSpawnBleedingTrailsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SelectSpawnBleedingTrailsSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BleedSpawnList,
                    GameMatcher.BleedingTrailSpawnAvailable,
                    GameMatcher.Bleeding));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                BleedingTrailData longTrailData = null;
                BleedingTrailData splashData;

                if (entity.Speed >= entity.LongBleedTrailSpeed)
                {
                    longTrailData = entity.BleedingTrails[BleedingTrailTypeId.Long].PickRandom();
                    splashData = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();
                }
                else
                {
                    splashData = entity.BleedingTrails[BleedingTrailTypeId.Splash].PickRandom();
                }

                if (longTrailData != null)
                    entity.BleedSpawnList.Add(longTrailData);

                entity.BleedSpawnList.Add(splashData);
            }
        }
    }
}