using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.KickingBacks
{
    [Game] public class KickingBackCooldownLeft : IComponent { public float Value; }
    [Game] public class KickingBackCooldown : IComponent { public float Value; }
    [Game] public class KickingBackCooldownUp : IComponent {  }
    
    [Game] public class KickingBackDirection : IComponent { public Vector3 Value; }
    
    [Game] public class KickingBacking : IComponent {  }
    
    [Game] public class KickingBackForce : IComponent { public  float Value;  }
}