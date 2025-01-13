using Entitas;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Moving : IComponent {  }

    [Game] public class MovingAvailable : IComponent {  }

    [Game] public class TurnAlongDirection : IComponent {  }
    
    [Game] public class RotateAlongDirection : IComponent {  }
}