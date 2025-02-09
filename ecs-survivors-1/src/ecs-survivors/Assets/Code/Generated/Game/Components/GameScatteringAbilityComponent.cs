//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherScatteringAbility;

    public static Entitas.IMatcher<GameEntity> ScatteringAbility {
        get {
            if (_matcherScatteringAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ScatteringAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScatteringAbility = matcher;
            }

            return _matcherScatteringAbility;
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

    static readonly Code.Gameplay.Features.Abilities.ScatteringAbility scatteringAbilityComponent = new Code.Gameplay.Features.Abilities.ScatteringAbility();

    public bool isScatteringAbility {
        get { return HasComponent(GameComponentsLookup.ScatteringAbility); }
        set {
            if (value != isScatteringAbility) {
                var index = GameComponentsLookup.ScatteringAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : scatteringAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
