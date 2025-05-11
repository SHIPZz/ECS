using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Factory
{
    public interface IBleedingTrailEntityFactory
    {
        GameEntity Create(Vector3 at, Quaternion rotation, Transform parent, BleedingTrailData data);
    }
}