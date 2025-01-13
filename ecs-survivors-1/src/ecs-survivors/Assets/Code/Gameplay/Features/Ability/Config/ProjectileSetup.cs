using System;

namespace Code.Gameplay.Features.Ability.Config
{
    [Serializable]
    public class ProjectileSetup
    {
        public float Speed;
        public int Pierce = 1;
        
        public float ContactRadius = 0.3f;
        public float CollectTargetInterval = 0.2f;
        
        public float Lifetime = 5f;
        public float Damage = 1;
        
        public int BouncingCount = 1;
        public int ScatteringCount;
        
        public float RadialRadius = 2f;
        public int RadialCount = 4;
    }
}