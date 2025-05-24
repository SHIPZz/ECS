using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Factory;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public sealed class SpawnTrailOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _spawnRequests;
        private readonly IBleedingTrailEntityFactory _bleedingTrailFactory;
        private readonly List<GameEntity> _buffer = new(32);

        public SpawnTrailOnRequestSystem(GameContext game, IBleedingTrailEntityFactory bleedingTrailFactory)
        {
            _spawnRequests = game.GetGroup(GameMatcher.BloodTrailRequest);
            _bleedingTrailFactory = bleedingTrailFactory;
        }

        public void Execute()
        {
            foreach (GameEntity requestEntity in _spawnRequests.GetEntities(_buffer))
            {
                BloodTrailRequest request = requestEntity.BloodTrailRequest;

                BleedingTrailData bleedingTrailData = request.BleedingTrails[request.TypeId].PickRandom();
                
                _bleedingTrailFactory.Create(request.Position, request.Rotation, null, bleedingTrailData);

                requestEntity.Destroy();
            }
        }
    }
} 