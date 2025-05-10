using System;
using Code.Gameplay.Features.BleedingTrails.Visuals;

namespace Code.Gameplay.Features.BleedingTrails.Configs
{
    [Serializable]
    public class BleedingTrailData
    {
        public BleedingTrailView Prefab;
        public float SpawnInterval = 0.1f;
        public int Layer = 1;
    }
}