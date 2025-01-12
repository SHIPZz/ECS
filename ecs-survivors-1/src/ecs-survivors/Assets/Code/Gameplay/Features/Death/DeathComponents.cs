using Entitas;

namespace Code.Gameplay.Features.Death
{
    [Game] public class Dead : IComponent { }
    
    [Game] public class DeathProcessing : IComponent { }
    
    [Game] public class DeathAnimationTime : IComponent { public float Value; }
}