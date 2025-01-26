using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    
    [Game] public class Moving : IComponent {  }

    [Game] public class MovingAvailable : IComponent {  }

    [Game] public class TurnAlongDirection : IComponent {  }
    
    [Game] public class RotateAlongDirection : IComponent {  }
    
    [Game] public class OrbitRadius : IComponent { public float Value; }
    
    [Game] public class OrbitPhase : IComponent { public float Value; }
    
    [Game] public class OrbitCenterFollowTarget : IComponent { public int Value; }
    
    [Game] public class OrbitCenterPosition: IComponent { public Vector3 Value; }
    
}
