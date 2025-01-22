using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Armament
{
    [Game] public class VegetableBoltArmament : IComponent {  }
    
    [Game] public class RadialBoltArmament : IComponent {  }
    
    [Game] public class BouncingArmament : IComponent {  }
    
    [Game] public class ScatteringArmament : IComponent {  }
    
    [Game] public class PoisonArmament : IComponent {  }
    
    [Game] public class VampirismArmament : IComponent {  }
    
    [Game] public class ArmamentProducerId : IComponent { public int Value; }
    
    [Game] public class VampireId : IComponent { public int Id; }

    [Game] public class Armament : IComponent { }
    
    [Game] public class Processed : IComponent {  }
    
    [Game] public class PoisonTimeUp : IComponent {  }
    
    [Game] public class PoisonTimeLeft: IComponent { public float Value; }
    
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    
    [Game] public class Poisoned: IComponent {  }
    
    [Game] public class PoisonDamage: IComponent { public float Value; }
    
    [Game] public class PoisonTime: IComponent { public float Value; }
    
    [Game] public class ContactRadius: IComponent { public float Value; }
    
    [Game] public class BouncingCount: IComponent { public int Value; }
        
    [Game] public class MaxBouncingCount: IComponent { public int Value; }
}