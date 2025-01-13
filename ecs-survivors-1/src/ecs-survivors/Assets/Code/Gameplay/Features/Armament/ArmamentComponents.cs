using Entitas;

namespace Code.Gameplay.Features.Armament
{
    [Game] public class VegetableBoltArmament : IComponent {  }
    
    [Game] public class RadialBoltArmament : IComponent {  }
    
    [Game] public class BouncingArmament : IComponent {  }
    
    [Game] public class ScatteringArmament : IComponent {  }

    [Game] public class Armament : IComponent { }
    
    [Game] public class Processed : IComponent {  }

    [Game] public class ContactRadius: IComponent { public float Value; }
    
    [Game] public class BouncingCount: IComponent { public int Value; }
        
    [Game] public class MaxBouncingCount: IComponent { public int Value; }
}