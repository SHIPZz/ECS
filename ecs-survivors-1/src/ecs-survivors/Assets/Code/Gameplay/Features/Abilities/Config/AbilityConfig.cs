using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Config
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Gameplay/AbilityConfig", order = 1)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityTypeId AbilityTypeId;
        
        public List<AbilityLevel> AbilityLevels;
    }
}