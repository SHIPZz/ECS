//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReadyToCollectOnMovingFinished;

    public static Entitas.IMatcher<GameEntity> ReadyToCollectOnMovingFinished {
        get {
            if (_matcherReadyToCollectOnMovingFinished == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReadyToCollectOnMovingFinished);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReadyToCollectOnMovingFinished = matcher;
            }

            return _matcherReadyToCollectOnMovingFinished;
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

    static readonly Code.Gameplay.Features.TargetCollection.ReadyToCollectOnMovingFinished readyToCollectOnMovingFinishedComponent = new Code.Gameplay.Features.TargetCollection.ReadyToCollectOnMovingFinished();

    public bool isReadyToCollectOnMovingFinished {
        get { return HasComponent(GameComponentsLookup.ReadyToCollectOnMovingFinished); }
        set {
            if (value != isReadyToCollectOnMovingFinished) {
                var index = GameComponentsLookup.ReadyToCollectOnMovingFinished;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : readyToCollectOnMovingFinishedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
