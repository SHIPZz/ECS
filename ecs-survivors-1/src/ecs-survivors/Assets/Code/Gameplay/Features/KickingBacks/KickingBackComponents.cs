using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.KickingBacks
{
    [Game] public class KickingBackDirection : IComponent { public Vector3 Value; }
    
    [Game] public class KickingBacking : IComponent {  }
    
    [Game] public class KickingBackAvailable : IComponent {  }
    
    [Game] public class KickingBackForce : IComponent { public  float Value;  }
    
    [Game] public class KickingBackInitialForce : IComponent { public  float Value;  }
    
    [Game] public class KickingBackStopForce : IComponent { public  float Value;  }
    
    [Game] public class KickingBackDamping : IComponent { public  float Value;  }
}