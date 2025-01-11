using Code.Gameplay.Common.Visuals;
using Code.Infrastructure.View;
using Entitas;

namespace Code.Common
{
    [Game] public class View : IComponent { public IEntityView Value; }

    [Game] public class Destructed : IComponent { }
    
    [Game] public class LayerMaskComponent : IComponent { public int Value; }
    
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
}