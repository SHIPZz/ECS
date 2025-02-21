//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDestructOnMovingFinished;

    public static Entitas.IMatcher<GameEntity> DestructOnMovingFinished {
        get {
            if (_matcherDestructOnMovingFinished == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DestructOnMovingFinished);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDestructOnMovingFinished = matcher;
            }

            return _matcherDestructOnMovingFinished;
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

    static readonly Code.Gameplay.Features.Movement.DestructOnMovingFinished destructOnMovingFinishedComponent = new Code.Gameplay.Features.Movement.DestructOnMovingFinished();

    public bool isDestructOnMovingFinished {
        get { return HasComponent(GameComponentsLookup.DestructOnMovingFinished); }
        set {
            if (value != isDestructOnMovingFinished) {
                var index = GameComponentsLookup.DestructOnMovingFinished;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destructOnMovingFinishedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
