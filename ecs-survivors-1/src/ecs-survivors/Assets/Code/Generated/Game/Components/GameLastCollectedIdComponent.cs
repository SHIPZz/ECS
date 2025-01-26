//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLastCollectedId;

    public static Entitas.IMatcher<GameEntity> LastCollectedId {
        get {
            if (_matcherLastCollectedId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastCollectedId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastCollectedId = matcher;
            }

            return _matcherLastCollectedId;
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

    public Code.Gameplay.Features.TargetCollection.LastCollectedId lastCollectedId { get { return (Code.Gameplay.Features.TargetCollection.LastCollectedId)GetComponent(GameComponentsLookup.LastCollectedId); } }
    public int LastCollectedId { get { return lastCollectedId.Value; } }
    public bool hasLastCollectedId { get { return HasComponent(GameComponentsLookup.LastCollectedId); } }

    public GameEntity AddLastCollectedId(int newValue) {
        var index = GameComponentsLookup.LastCollectedId;
        var component = (Code.Gameplay.Features.TargetCollection.LastCollectedId)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.LastCollectedId));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLastCollectedId(int newValue) {
        var index = GameComponentsLookup.LastCollectedId;
        var component = (Code.Gameplay.Features.TargetCollection.LastCollectedId)CreateComponent(index, typeof(Code.Gameplay.Features.TargetCollection.LastCollectedId));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLastCollectedId() {
        RemoveComponent(GameComponentsLookup.LastCollectedId);
        return this;
    }
}
