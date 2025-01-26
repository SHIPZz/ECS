//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMaxHpIncrease;

    public static Entitas.IMatcher<GameEntity> MaxHpIncrease {
        get {
            if (_matcherMaxHpIncrease == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxHpIncrease);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxHpIncrease = matcher;
            }

            return _matcherMaxHpIncrease;
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

    static readonly Code.Gameplay.Features.Statuses.MaxHpIncrease maxHpIncreaseComponent = new Code.Gameplay.Features.Statuses.MaxHpIncrease();

    public bool isMaxHpIncrease {
        get { return HasComponent(GameComponentsLookup.MaxHpIncrease); }
        set {
            if (value != isMaxHpIncrease) {
                var index = GameComponentsLookup.MaxHpIncrease;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : maxHpIncreaseComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
