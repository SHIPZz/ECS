//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }
    public InputContext input { get; set; }
    public MetaContext meta { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, input, meta }; } }

    public Contexts() {
        game = new GameContext();
        input = new InputContext();
        meta = new MetaContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string ApplierStatusLink = "ApplierStatusLink";
    public const string EntityLink = "EntityLink";
    public const string Id = "Id";
    public const string ParentAbility = "ParentAbility";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ApplierStatusLink,
            game.GetGroup(GameMatcher.ApplierStatusLink),
            (e, c) => ((Code.Gameplay.Features.Statuses.ApplierStatusLink)c).Value));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            EntityLink,
            game.GetGroup(GameMatcher.EntityLink),
            (e, c) => ((Code.Gameplay.Common.EntityLink)c).Value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            Id,
            game.GetGroup(GameMatcher.Id),
            (e, c) => ((Code.Gameplay.Common.Id)c).Value));
        meta.AddEntityIndex(new Entitas.PrimaryEntityIndex<MetaEntity, int>(
            Id,
            meta.GetGroup(MetaMatcher.Id),
            (e, c) => ((Code.Gameplay.Common.Id)c).Value));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, Code.Gameplay.Features.Abilities.Config.AbilityTypeId>(
            ParentAbility,
            game.GetGroup(GameMatcher.ParentAbility),
            (e, c) => ((Code.Gameplay.Features.Abilities.ParentAbility)c).Value));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithApplierStatusLink(this GameContext context, int Value) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ApplierStatusLink)).GetEntities(Value);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithEntityLink(this GameContext context, int Value) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.EntityLink)).GetEntities(Value);
    }

    public static GameEntity GetEntityWithId(this GameContext context, int Value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }

    public static MetaEntity GetEntityWithId(this MetaContext context, int Value) {
        return ((Entitas.PrimaryEntityIndex<MetaEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithParentAbility(this GameContext context, Code.Gameplay.Features.Abilities.Config.AbilityTypeId Value) {
        return ((Entitas.EntityIndex<GameEntity, Code.Gameplay.Features.Abilities.Config.AbilityTypeId>)context.GetEntityIndex(Contexts.ParentAbility)).GetEntities(Value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(game);
            CreateContextObserver(input);
            CreateContextObserver(meta);
        } catch(System.Exception e) {
            UnityEngine.Debug.LogError(e);
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
