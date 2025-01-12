using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Ability
{
    [Serializable]
    public class ProjectileSetup
    {
        public EntityBehaviour Prefab;
        public float Speed;
        public int Pierce = 1;
        public float CollectTargetInterval = 0.2f;
        public float Damage = 1;
    }
}