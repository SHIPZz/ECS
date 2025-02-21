//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherParentAbility;

    public static Entitas.IMatcher<GameEntity> ParentAbility {
        get {
            if (_matcherParentAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ParentAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherParentAbility = matcher;
            }

            return _matcherParentAbility;
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

    public Code.Gameplay.Features.Abilities.ParentAbility parentAbility { get { return (Code.Gameplay.Features.Abilities.ParentAbility)GetComponent(GameComponentsLookup.ParentAbility); } }
    public Code.Gameplay.Features.Abilities.Config.AbilityTypeId ParentAbility { get { return parentAbility.Value; } }
    public bool hasParentAbility { get { return HasComponent(GameComponentsLookup.ParentAbility); } }

    public GameEntity AddParentAbility(Code.Gameplay.Features.Abilities.Config.AbilityTypeId newValue) {
        var index = GameComponentsLookup.ParentAbility;
        var component = (Code.Gameplay.Features.Abilities.ParentAbility)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.ParentAbility));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceParentAbility(Code.Gameplay.Features.Abilities.Config.AbilityTypeId newValue) {
        var index = GameComponentsLookup.ParentAbility;
        var component = (Code.Gameplay.Features.Abilities.ParentAbility)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.ParentAbility));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveParentAbility() {
        RemoveComponent(GameComponentsLookup.ParentAbility);
        return this;
    }
}
