//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVampireId;

    public static Entitas.IMatcher<GameEntity> VampireId {
        get {
            if (_matcherVampireId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VampireId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVampireId = matcher;
            }

            return _matcherVampireId;
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

    public Code.Gameplay.Features.Armament.VampireId vampireId { get { return (Code.Gameplay.Features.Armament.VampireId)GetComponent(GameComponentsLookup.VampireId); } }
    public bool hasVampireId { get { return HasComponent(GameComponentsLookup.VampireId); } }

    public GameEntity AddVampireId(int newId) {
        var index = GameComponentsLookup.VampireId;
        var component = (Code.Gameplay.Features.Armament.VampireId)CreateComponent(index, typeof(Code.Gameplay.Features.Armament.VampireId));
        component.Id = newId;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceVampireId(int newId) {
        var index = GameComponentsLookup.VampireId;
        var component = (Code.Gameplay.Features.Armament.VampireId)CreateComponent(index, typeof(Code.Gameplay.Features.Armament.VampireId));
        component.Id = newId;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveVampireId() {
        RemoveComponent(GameComponentsLookup.VampireId);
        return this;
    }
}
