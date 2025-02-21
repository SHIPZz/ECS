//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEndPoint;

    public static Entitas.IMatcher<GameEntity> EndPoint {
        get {
            if (_matcherEndPoint == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EndPoint);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEndPoint = matcher;
            }

            return _matcherEndPoint;
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

    public Code.Gameplay.Features.Movement.EndPoint endPoint { get { return (Code.Gameplay.Features.Movement.EndPoint)GetComponent(GameComponentsLookup.EndPoint); } }
    public UnityEngine.Vector3 EndPoint { get { return endPoint.Value; } }
    public bool hasEndPoint { get { return HasComponent(GameComponentsLookup.EndPoint); } }

    public GameEntity AddEndPoint(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EndPoint;
        var component = (Code.Gameplay.Features.Movement.EndPoint)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.EndPoint));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEndPoint(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.EndPoint;
        var component = (Code.Gameplay.Features.Movement.EndPoint)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.EndPoint));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEndPoint() {
        RemoveComponent(GameComponentsLookup.EndPoint);
        return this;
    }
}
