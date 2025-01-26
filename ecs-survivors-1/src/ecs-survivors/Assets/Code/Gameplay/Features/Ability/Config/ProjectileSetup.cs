﻿using System;
using UnityEngine;

namespace Code.Gameplay.Features.Ability.Config
{
    [Serializable]
    public class ProjectileSetup
    {
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

        public float PoisonDuration = 3f;
        public float PoisonDamage = 5f;

        public float ProjectileCount = 1;
        
        public float OrbitRadius = 1f;
    }
}