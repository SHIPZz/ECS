//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCollectingAvailable;

    public static Entitas.IMatcher<GameEntity> CollectingAvailable {
        get {
            if (_matcherCollectingAvailable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollectingAvailable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollectingAvailable = matcher;
            }

            return _matcherCollectingAvailable;
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

    static readonly Code.Gameplay.Features.TargetCollection.CollectingAvailable collectingAvailableComponent = new Code.Gameplay.Features.TargetCollection.CollectingAvailable();

    public bool isCollectingAvailable {
        get { return HasComponent(GameComponentsLookup.CollectingAvailable); }
        set {
            if (value != isCollectingAvailable) {
                var index = GameComponentsLookup.CollectingAvailable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : collectingAvailableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
