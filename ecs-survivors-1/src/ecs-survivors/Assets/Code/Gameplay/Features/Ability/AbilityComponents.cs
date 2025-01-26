using Code.Gameplay.Features.Ability.Config;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Ability
{
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    
    [Game] public class TargetLimit : IComponent { public int Value; }
    
    [Game] public class RadialRadius : IComponent { public float Value; }

    [Game] public class ScatteringCount : IComponent { public int Value; }
    
    [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityTypeId Value; }
    
    [Game] public class VegetableBoltAbility : IComponent {  }
    
    [Game] public class OrbitingMushroomAbility : IComponent {  }

    [Game] public class GarlicAuraAbility : IComponent {  }
    
    [Game] public class MagnificentBoltAbility : IComponent {  }

    [Game] public class SpeedUpAbility : IComponent {  }
    
    [Game] public class IncreaseMaxHpAbility : IComponent {  }
    
    [Game] public class PoisonAbility : IComponent {  }
    
    [Game] public class ScatteringAbility : IComponent {  }
    
    [Game] public class RadialAbility : IComponent {  }
    
    [Game] public class BouncingAbility : IComponent {  }
    
    [Game] public class VampirismAbility : IComponent {  }
}