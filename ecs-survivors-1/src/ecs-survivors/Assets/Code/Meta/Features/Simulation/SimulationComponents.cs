using Code.Progress;
using Entitas;

namespace Code.Meta.Features.Simulation
{
    [Meta] public class Tick : ISavedComponent { public float Value; }
    
    [Meta] public class GoldGainBoost : ISavedComponent { public float Value; }
    
    [Meta] public class Duration : IComponent { public float Value; }
    
    [Meta] public class AppearChance : IComponent { public float Value; }
    
    [Meta] public class RollTime : IComponent { public float Value; }

    [Meta] public class RollComponent : IComponent { public float Value; }
    
    [Meta] public class RollTimeLeft : IComponent { public float Value; }
    
    [Meta] public class RollTimeUp : IComponent {  }
    
}