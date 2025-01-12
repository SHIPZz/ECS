using System.Collections.Generic;

namespace Code.Gameplay.Features.Ability
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Gameplay/AbilityConfig", order = 1)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityTypeId AbilityTypeId;
        
        public float Cooldown = 1f;
        
        public List<AbilityLevel> AbilityLevels;
    }
}