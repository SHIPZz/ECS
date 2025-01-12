//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDeathAnimationTime;

    public static Entitas.IMatcher<GameEntity> DeathAnimationTime {
        get {
            if (_matcherDeathAnimationTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DeathAnimationTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDeathAnimationTime = matcher;
            }

            return _matcherDeathAnimationTime;
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

    public Code.Gameplay.Features.Death.DeathAnimationTime deathAnimationTime { get { return (Code.Gameplay.Features.Death.DeathAnimationTime)GetComponent(GameComponentsLookup.DeathAnimationTime); } }
    public float DeathAnimationTime { get { return deathAnimationTime.Value; } }
    public bool hasDeathAnimationTime { get { return HasComponent(GameComponentsLookup.DeathAnimationTime); } }

    public GameEntity AddDeathAnimationTime(float newValue) {
        var index = GameComponentsLookup.DeathAnimationTime;
        var component = (Code.Gameplay.Features.Death.DeathAnimationTime)CreateComponent(index, typeof(Code.Gameplay.Features.Death.DeathAnimationTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDeathAnimationTime(float newValue) {
        var index = GameComponentsLookup.DeathAnimationTime;
        var component = (Code.Gameplay.Features.Death.DeathAnimationTime)CreateComponent(index, typeof(Code.Gameplay.Features.Death.DeathAnimationTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDeathAnimationTime() {
        RemoveComponent(GameComponentsLookup.DeathAnimationTime);
        return this;
    }
}
