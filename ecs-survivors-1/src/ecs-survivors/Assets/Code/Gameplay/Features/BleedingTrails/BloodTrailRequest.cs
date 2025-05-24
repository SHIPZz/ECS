using System.Collections.Generic;
using Code.Gameplay.Features.BleedingTrails.Configs;
using UnityEngine;
using Code.Gameplay.Features.BleedingTrails.Enums;

namespace Code.Gameplay.Features.BleedingTrails
{
    public struct BloodTrailRequest
    {
        public BleedingTrailTypeId TypeId;
        public Vector3 Position;
        public Quaternion Rotation;
        public Dictionary<BleedingTrailTypeId, List<BleedingTrailData>> BleedingTrails;

        public BloodTrailRequest(BleedingTrailTypeId typeId, Vector3 position, Quaternion rotation, Dictionary<BleedingTrailTypeId, List<BleedingTrailData>> bleedingTrails)
        {
            TypeId = typeId;
            Position = position;
            Rotation = rotation;
            BleedingTrails = bleedingTrails;
        }
    }
} 