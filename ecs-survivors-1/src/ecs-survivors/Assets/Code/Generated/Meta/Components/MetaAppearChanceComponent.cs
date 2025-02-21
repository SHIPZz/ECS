//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherAppearChance;

    public static Entitas.IMatcher<MetaEntity> AppearChance {
        get {
            if (_matcherAppearChance == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.AppearChance);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherAppearChance = matcher;
            }

            return _matcherAppearChance;
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
public partial class MetaEntity {

    public Code.Meta.Features.Simulation.AppearChance appearChance { get { return (Code.Meta.Features.Simulation.AppearChance)GetComponent(MetaComponentsLookup.AppearChance); } }
    public float AppearChance { get { return appearChance.Value; } }
    public bool hasAppearChance { get { return HasComponent(MetaComponentsLookup.AppearChance); } }

    public MetaEntity AddAppearChance(float newValue) {
        var index = MetaComponentsLookup.AppearChance;
        var component = (Code.Meta.Features.Simulation.AppearChance)CreateComponent(index, typeof(Code.Meta.Features.Simulation.AppearChance));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public MetaEntity ReplaceAppearChance(float newValue) {
        var index = MetaComponentsLookup.AppearChance;
        var component = (Code.Meta.Features.Simulation.AppearChance)CreateComponent(index, typeof(Code.Meta.Features.Simulation.AppearChance));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public MetaEntity RemoveAppearChance() {
        RemoveComponent(MetaComponentsLookup.AppearChance);
        return this;
    }
}
