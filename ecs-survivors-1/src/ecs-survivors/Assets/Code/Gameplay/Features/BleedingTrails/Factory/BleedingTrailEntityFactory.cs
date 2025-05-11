using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.BleedingTrails.Factory
{
    public class BleedingTrailEntityFactory : IBleedingTrailEntityFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IInstantiator _instantiator;

        public BleedingTrailEntityFactory(IInstantiator instantiator, IIdentifierService identifierService)
        {
            _instantiator = instantiator;
            _identifierService = identifierService;
        }

        public GameEntity Create(Vector3 at, Quaternion rotation, Transform parent, BleedingTrailData data)
        {
            GameEntity bleedingTrailEntity = CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddWorldPosition(at)
                    .AddBleedTrailView(CreateView(at, rotation, data))
                    .AddSelfDestructTimer(data.DestroyTime)
                    .With(x => x.isBleedingTrail = true)
                    .With(x => x.isRotateAlongDirection = true)
                ;

            return bleedingTrailEntity;
        }

        private BleedingTrailView CreateView(Vector3 at, Quaternion rotation, BleedingTrailData data)
        {
            return _instantiator.InstantiatePrefabForComponent<BleedingTrailView>(
                data.Prefab,
                at,
                rotation,
                null);
        }
    }
}