using Code.Gameplay.Features.Ability.Config;
using Entitas;

namespace Code.Gameplay.Features.Ability
{
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    
    [Game] public class TargetLimit : IComponent { public int Value; }

    [Game]
    public class RadialRadius : IComponent { public float Value; }

    [Game] public class ScatteringCount : IComponent { public int Value; }
    
    [Game] public class VegetableBoltAbility : IComponent {  }
    
    [Game] public class ScatteringAbility : IComponent {  }
    
    [Game] public class RadialAbility : IComponent {  }
    
    [Game] public class BouncingAbility : IComponent {  }
}