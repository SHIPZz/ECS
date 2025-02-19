//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherTargetAmount;

    public static Entitas.IMatcher<MetaEntity> TargetAmount {
        get {
            if (_matcherTargetAmount == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.TargetAmount);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherTargetAmount = matcher;
            }

            return _matcherTargetAmount;
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

    public Code.Meta.Features.Achievements.TargetAmount targetAmount { get { return (Code.Meta.Features.Achievements.TargetAmount)GetComponent(MetaComponentsLookup.TargetAmount); } }
    public float TargetAmount { get { return targetAmount.Value; } }
    public bool hasTargetAmount { get { return HasComponent(MetaComponentsLookup.TargetAmount); } }

    public MetaEntity AddTargetAmount(float newValue) {
        var index = MetaComponentsLookup.TargetAmount;
        var component = (Code.Meta.Features.Achievements.TargetAmount)CreateComponent(index, typeof(Code.Meta.Features.Achievements.TargetAmount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public MetaEntity ReplaceTargetAmount(float newValue) {
        var index = MetaComponentsLookup.TargetAmount;
        var component = (Code.Meta.Features.Achievements.TargetAmount)CreateComponent(index, typeof(Code.Meta.Features.Achievements.TargetAmount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public MetaEntity RemoveTargetAmount() {
        RemoveComponent(MetaComponentsLookup.TargetAmount);
        return this;
    }
}
