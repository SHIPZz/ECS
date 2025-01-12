using Entitas;

namespace Code.Gameplay.Features.Ability
{
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    
    [Game] public class TargetLimit : IComponent { public int Value; }
    
    [Game] public class VegetableBoltAbility : IComponent {  }
}