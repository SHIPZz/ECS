﻿using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Statuses;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Config
{
    [Serializable]
    public class ProjectileSetup
    {
        public List<StatusSetup> StatusesContainer;

        public LayerMask Mask;
        public float Speed;
        public int Pierce = 1;
        
        public float ContactRadius = 0.3f;
        public float CollectTargetInterval = 0.2f;
        
        public float Lifetime = 5f;
        public float Damage = 1;

        public int AdditionalProjectileCount;
        public int AdditionalProjectileHitCount;
        
        public int BouncingCount = 1;
        public int ScatteringCount;
        
        public float RadialRadius = 2f;
        public int RadialCount = 4;

        public float ProjectileCount = 1;
        
        public float OrbitRadius = 1f;
        
        public int MinCountToPullTargets = 1;
        public int MaxCountToPullTargets = 3;
        public bool DestructOnMaxPullTargetReached = true;
    }
}