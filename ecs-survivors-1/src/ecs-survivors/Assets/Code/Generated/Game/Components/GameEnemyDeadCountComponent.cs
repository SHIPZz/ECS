//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnemyDeadCount;

    public static Entitas.IMatcher<GameEntity> EnemyDeadCount {
        get {
            if (_matcherEnemyDeadCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyDeadCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyDeadCount = matcher;
            }

            return _matcherEnemyDeadCount;
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

    public Code.Gameplay.Features.Enemies.EnemyDeadCount enemyDeadCount { get { return (Code.Gameplay.Features.Enemies.EnemyDeadCount)GetComponent(GameComponentsLookup.EnemyDeadCount); } }
    public int EnemyDeadCount { get { return enemyDeadCount.Value; } }
    public bool hasEnemyDeadCount { get { return HasComponent(GameComponentsLookup.EnemyDeadCount); } }

    public GameEntity AddEnemyDeadCount(int newValue) {
        var index = GameComponentsLookup.EnemyDeadCount;
        var component = (Code.Gameplay.Features.Enemies.EnemyDeadCount)CreateComponent(index, typeof(Code.Gameplay.Features.Enemies.EnemyDeadCount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEnemyDeadCount(int newValue) {
        var index = GameComponentsLookup.EnemyDeadCount;
        var component = (Code.Gameplay.Features.Enemies.EnemyDeadCount)CreateComponent(index, typeof(Code.Gameplay.Features.Enemies.EnemyDeadCount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEnemyDeadCount() {
        RemoveComponent(GameComponentsLookup.EnemyDeadCount);
        return this;
    }
}
