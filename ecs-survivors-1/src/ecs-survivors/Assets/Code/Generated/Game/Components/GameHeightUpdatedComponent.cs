//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHeightUpdated;

    public static Entitas.IMatcher<GameEntity> HeightUpdated {
        get {
            if (_matcherHeightUpdated == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HeightUpdated);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHeightUpdated = matcher;
            }

            return _matcherHeightUpdated;
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

    static readonly Code.Gameplay.Features.Movement.HeightUpdated heightUpdatedComponent = new Code.Gameplay.Features.Movement.HeightUpdated();

    public bool isHeightUpdated {
        get { return HasComponent(GameComponentsLookup.HeightUpdated); }
        set {
            if (value != isHeightUpdated) {
                var index = GameComponentsLookup.HeightUpdated;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : heightUpdatedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
