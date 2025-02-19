//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherKillEnemyAchievement;

    public static Entitas.IMatcher<MetaEntity> KillEnemyAchievement {
        get {
            if (_matcherKillEnemyAchievement == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.KillEnemyAchievement);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherKillEnemyAchievement = matcher;
            }

            return _matcherKillEnemyAchievement;
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

    static readonly Code.Meta.Features.Achievements.KillEnemyAchievement killEnemyAchievementComponent = new Code.Meta.Features.Achievements.KillEnemyAchievement();

    public bool isKillEnemyAchievement {
        get { return HasComponent(MetaComponentsLookup.KillEnemyAchievement); }
        set {
            if (value != isKillEnemyAchievement) {
                var index = MetaComponentsLookup.KillEnemyAchievement;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : killEnemyAchievementComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
