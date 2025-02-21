//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherNeedRandomEndPoint;

    public static Entitas.IMatcher<GameEntity> NeedRandomEndPoint {
        get {
            if (_matcherNeedRandomEndPoint == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NeedRandomEndPoint);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNeedRandomEndPoint = matcher;
            }

            return _matcherNeedRandomEndPoint;
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

    static readonly Code.Gameplay.Features.Movement.NeedRandomEndPoint needRandomEndPointComponent = new Code.Gameplay.Features.Movement.NeedRandomEndPoint();

    public bool isNeedRandomEndPoint {
        get { return HasComponent(GameComponentsLookup.NeedRandomEndPoint); }
        set {
            if (value != isNeedRandomEndPoint) {
                var index = GameComponentsLookup.NeedRandomEndPoint;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : needRandomEndPointComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
