using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Armament
{
    [Game] public class VegetableBoltArmament : IComponent { }

    [Game] public class MagnificentBoltArmament : IComponent {  }
    
    [Game] public class RadialBoltArmament : IComponent {  }
    
    [Game] public class FollowingProducer : IComponent {  }
    
    [Game] public class BouncingArmament : IComponent {  }
    
    [Game] public class BleedingProvocateurArmament : IComponent {  }
    
    [Game] public class ScatteringArmament : IComponent {  }
    
    [Game] public class OrbitalMushroomArmament : IComponent {  }

    [Game] public class ArmamentProducerId : IComponent { public int Value; }

    [Game] public class AuraTypeIdComponent : IComponent { public AuraTypeId Value; }
    
    [Game] public class Armament : IComponent { }
    
    [Game] public class PullingArmament : IComponent { }
    
    [Game] public class Aura : IComponent { }
    
    [Game] public class HealAura : IComponent { }
    
    [Game] public class Processed : IComponent {  }
    
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    
    [Game] public class Poisoned: IComponent {  }
    
    [Game] public class ContactRadius: IComponent { public float Value; }
    
    [Game] public class BouncingCount: IComponent { public int Value; }
    
    [Game] public class PullTargetId: IComponent { public int Value; }
    
    [Game] public class PullProducerId: IComponent { public int Value; }
    
    [Game] public class AdditionalProjectileCount: IComponent { public int Value; }
    
    [Game] public class AdditionalProjectileHitCount: IComponent { public int Value; }
        
    [Game] public class MaxBouncingCount: IComponent { public int Value; }
}