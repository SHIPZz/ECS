using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    
    [Game] public class InitialSpeed : IComponent { public float Value; }
    
    [Game] public class AnimationDuration : IComponent { public float Value; }
    
    [Game] public class ElapsedTime : IComponent { public float Value; }
    
    [Game] public class AnimationCurveComponent : IComponent { public AnimationCurve Value; }
    
    [Game] public class UpdateHeightBySinCurve : IComponent {  }
    
    [Game] public class HeightUpdated : IComponent {  }
    
    [Game] public class StartHeight : IComponent { public float Value; }

    [Game] public class Moving : IComponent {  }
    
    [Game] public class DestructOnMovingFinished : IComponent {  }
    
    [Game] public class MovingAvailable : IComponent {  }

    [Game] public class TurnAlongDirection : IComponent {  }
    
    [Game] public class RotateAlongDirection : IComponent {  }
    
    [Game] public class EndPoint : IComponent { public Vector3 Value; }
    
    [Game] public class EndPointReached : IComponent {  }

    [Game] public class NeedRandomEndPoint : IComponent {  }
    
    [Game] public class OrbitRadius : IComponent { public float Value; }
    
    [Game] public class OrbitPhase : IComponent { public float Value; }
    
    [Game] public class OrbitCenterFollowTarget : IComponent { public int Value; }
    
    [Game] public class OrbitCenterPosition: IComponent { public Vector3 Value; }
    
}
