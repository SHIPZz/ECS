//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherIncreaseMaxHpAbility;

    public static Entitas.IMatcher<GameEntity> IncreaseMaxHpAbility {
        get {
            if (_matcherIncreaseMaxHpAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IncreaseMaxHpAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIncreaseMaxHpAbility = matcher;
            }

            return _matcherIncreaseMaxHpAbility;
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

    static readonly Code.Gameplay.Features.Abilities.IncreaseMaxHpAbility increaseMaxHpAbilityComponent = new Code.Gameplay.Features.Abilities.IncreaseMaxHpAbility();

    public bool isIncreaseMaxHpAbility {
        get { return HasComponent(GameComponentsLookup.IncreaseMaxHpAbility); }
        set {
            if (value != isIncreaseMaxHpAbility) {
                var index = GameComponentsLookup.IncreaseMaxHpAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : increaseMaxHpAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
