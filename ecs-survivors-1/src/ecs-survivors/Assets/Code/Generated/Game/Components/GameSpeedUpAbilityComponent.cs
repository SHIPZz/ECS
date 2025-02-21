//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpeedUpAbility;

    public static Entitas.IMatcher<GameEntity> SpeedUpAbility {
        get {
            if (_matcherSpeedUpAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpeedUpAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpeedUpAbility = matcher;
            }

            return _matcherSpeedUpAbility;
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

    static readonly Code.Gameplay.Features.Abilities.SpeedUpAbility speedUpAbilityComponent = new Code.Gameplay.Features.Abilities.SpeedUpAbility();

    public bool isSpeedUpAbility {
        get { return HasComponent(GameComponentsLookup.SpeedUpAbility); }
        set {
            if (value != isSpeedUpAbility) {
                var index = GameComponentsLookup.SpeedUpAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : speedUpAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
