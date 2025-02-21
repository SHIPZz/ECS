//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherRollTimeUp;

    public static Entitas.IMatcher<MetaEntity> RollTimeUp {
        get {
            if (_matcherRollTimeUp == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.RollTimeUp);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherRollTimeUp = matcher;
            }

            return _matcherRollTimeUp;
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

    static readonly Code.Meta.Features.Simulation.RollTimeUp rollTimeUpComponent = new Code.Meta.Features.Simulation.RollTimeUp();

    public bool isRollTimeUp {
        get { return HasComponent(MetaComponentsLookup.RollTimeUp); }
        set {
            if (value != isRollTimeUp) {
                var index = MetaComponentsLookup.RollTimeUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rollTimeUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
