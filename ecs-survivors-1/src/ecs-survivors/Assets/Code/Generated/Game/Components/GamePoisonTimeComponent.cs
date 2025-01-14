//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPoisonTime;

    public static Entitas.IMatcher<GameEntity> PoisonTime {
        get {
            if (_matcherPoisonTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PoisonTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPoisonTime = matcher;
            }

            return _matcherPoisonTime;
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

    public Code.Gameplay.Features.Armament.PoisonTime poisonTime { get { return (Code.Gameplay.Features.Armament.PoisonTime)GetComponent(GameComponentsLookup.PoisonTime); } }
    public float PoisonTime { get { return poisonTime.Value; } }
    public bool hasPoisonTime { get { return HasComponent(GameComponentsLookup.PoisonTime); } }

    public GameEntity AddPoisonTime(float newValue) {
        var index = GameComponentsLookup.PoisonTime;
        var component = (Code.Gameplay.Features.Armament.PoisonTime)CreateComponent(index, typeof(Code.Gameplay.Features.Armament.PoisonTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePoisonTime(float newValue) {
        var index = GameComponentsLookup.PoisonTime;
        var component = (Code.Gameplay.Features.Armament.PoisonTime)CreateComponent(index, typeof(Code.Gameplay.Features.Armament.PoisonTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePoisonTime() {
        RemoveComponent(GameComponentsLookup.PoisonTime);
        return this;
    }
}
