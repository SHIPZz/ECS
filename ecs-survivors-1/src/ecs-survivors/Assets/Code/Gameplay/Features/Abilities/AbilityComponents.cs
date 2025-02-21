using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Config;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    
    [Game] public class AbilityHolder : IComponent { public List<AbilityTypeId> Value; }
    
    [Game] public class TargetLimit : IComponent { public int Value; }
    
    [Game] public class RadialRadius : IComponent { public float Value; }

    [Game] public class ScatteringCount : IComponent { public int Value; }
    
    [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityTypeId Value; }
    
    [Game] public class VegetableBoltAbility : IComponent {  }
    
    [Game] public class FireAuraAbility : IComponent {  }
    
    [Game] public class UpgradeRequest : IComponent {  }
    
    [Game] public class RecreatedOnUpdate : IComponent {  }
    
    [Game] public class OrbitingMushroomAbility : IComponent {  }

    [Game] public class GarlicAuraAbility : IComponent {  }
    
    [Game] public class SpecialBombAbility : IComponent {  }
    
    [Game] public class MagnificentBoltAbility : IComponent {  }

    [Game] public class SpeedUpAbility : IComponent {  }
    
    [Game] public class IncreaseMaxHpAbility : IComponent {  }
    
    [Game] public class PoisonAbility : IComponent {  }
    
    [Game] public class ScatteringAbility : IComponent {  }
    
    [Game] public class RadialAbility : IComponent {  }
    
    [Game] public class BouncingAbility : IComponent {  }
    
    [Game] public class VampirismAbility : IComponent {  }
    
}