//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRadialRadius;

    public static Entitas.IMatcher<GameEntity> RadialRadius {
        get {
            if (_matcherRadialRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RadialRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRadialRadius = matcher;
            }

            return _matcherRadialRadius;
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

    public Code.Gameplay.Features.Ability.RadialRadius radialRadius { get { return (Code.Gameplay.Features.Ability.RadialRadius)GetComponent(GameComponentsLookup.RadialRadius); } }
    public float RadialRadius { get { return radialRadius.Value; } }
    public bool hasRadialRadius { get { return HasComponent(GameComponentsLookup.RadialRadius); } }

    public GameEntity AddRadialRadius(float newValue) {
        var index = GameComponentsLookup.RadialRadius;
        var component = (Code.Gameplay.Features.Ability.RadialRadius)CreateComponent(index, typeof(Code.Gameplay.Features.Ability.RadialRadius));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRadialRadius(float newValue) {
        var index = GameComponentsLookup.RadialRadius;
        var component = (Code.Gameplay.Features.Ability.RadialRadius)CreateComponent(index, typeof(Code.Gameplay.Features.Ability.RadialRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRadialRadius() {
        RemoveComponent(GameComponentsLookup.RadialRadius);
        return this;
    }
}
