using System;
using Code.Gameplay.Features.BleedingTrails.Visuals;

namespace Code.Gameplay.Features.BleedingTrails.Configs
{
    [Serializable]
    public class BleedingTrailData
    {
        public BleedingTrailView Prefab;

        public float DestroyTime = 10f;
    }
}