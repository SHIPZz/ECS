//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVegetableBoltArmament;

    public static Entitas.IMatcher<GameEntity> VegetableBoltArmament {
        get {
            if (_matcherVegetableBoltArmament == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VegetableBoltArmament);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVegetableBoltArmament = matcher;
            }

            return _matcherVegetableBoltArmament;
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

    static readonly Code.Gameplay.Features.Armament.VegetableBoltArmament vegetableBoltArmamentComponent = new Code.Gameplay.Features.Armament.VegetableBoltArmament();

    public bool isVegetableBoltArmament {
        get { return HasComponent(GameComponentsLookup.VegetableBoltArmament); }
        set {
            if (value != isVegetableBoltArmament) {
                var index = GameComponentsLookup.VegetableBoltArmament;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vegetableBoltArmamentComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
