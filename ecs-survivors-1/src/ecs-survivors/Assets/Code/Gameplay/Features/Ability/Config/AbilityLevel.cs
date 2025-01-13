using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Ability.Config
{
    [Serializable]
    public class AbilityLevel
    {
        public float Cooldown = 1f;

        public EntityBehaviour Prefab;
        
        public ProjectileSetup ProjectileSetup;
    }
}