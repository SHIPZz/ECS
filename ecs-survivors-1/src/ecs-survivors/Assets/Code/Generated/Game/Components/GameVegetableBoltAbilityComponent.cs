//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVegetableBoltAbility;

    public static Entitas.IMatcher<GameEntity> VegetableBoltAbility {
        get {
            if (_matcherVegetableBoltAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VegetableBoltAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVegetableBoltAbility = matcher;
            }

            return _matcherVegetableBoltAbility;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Ability.VegetableBoltAbility vegetableBoltAbilityComponent = new Code.Gameplay.Features.Ability.VegetableBoltAbility();

    public bool isVegetableBoltAbility {
        get { return HasComponent(GameComponentsLookup.VegetableBoltAbility); }
        set {
            if (value != isVegetableBoltAbility) {
                var index = GameComponentsLookup.VegetableBoltAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vegetableBoltAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
