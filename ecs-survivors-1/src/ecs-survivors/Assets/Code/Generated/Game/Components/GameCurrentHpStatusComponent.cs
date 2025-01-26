//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentHpStatus;

    public static Entitas.IMatcher<GameEntity> CurrentHpStatus {
        get {
            if (_matcherCurrentHpStatus == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentHpStatus);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentHpStatus = matcher;
            }

            return _matcherCurrentHpStatus;
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

    static readonly Code.Gameplay.Features.Statuses.CurrentHpStatus currentHpStatusComponent = new Code.Gameplay.Features.Statuses.CurrentHpStatus();

    public bool isCurrentHpStatus {
        get { return HasComponent(GameComponentsLookup.CurrentHpStatus); }
        set {
            if (value != isCurrentHpStatus) {
                var index = GameComponentsLookup.CurrentHpStatus;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : currentHpStatusComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
