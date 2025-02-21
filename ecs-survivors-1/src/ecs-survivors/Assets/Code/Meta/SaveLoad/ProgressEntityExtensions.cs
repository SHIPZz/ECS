using System;
using System.Linq;
using Code.Common.Extensions;
using Code.Progress;
using Entitas;

namespace Code.Meta.SaveLoad
{
    public static class ProgressEntityExtensions
    {
        public static IEntity HydrateWith(this IEntity entity, EntitySnapshot entityData)
        {
            foreach (ISavedComponent component in entityData.Components)
            {
                int lookUpIndex = LookupIndexOf(component, entity);
                entity.With(x => x.ReplaceComponent(lookUpIndex, component), when: lookUpIndex >= 0);
            }
            
            return entity;
        }

        private static int LookupIndexOf(ISavedComponent component, IEntity entity)
        {
            return Array.IndexOf(ComponentTypes(entity), component.GetType());
        }

        private static Type[] ComponentTypes(IEntity entity)
        {
            return entity switch
            {
                MetaEntity => MetaComponentsLookup.componentTypes,
                GameEntity => GameComponentsLookup.componentTypes,
                _ => throw new ArgumentException($"requested look up for {entity.GetType().Name} is not implemented")
            };
                
            return MetaComponentsLookup.componentTypes;
        }

        public static EntitySnapshot AsSavedEntity(this IEntity entity)
        {
            IComponent[] components = entity.GetComponents();

            return new EntitySnapshot()
            {
                Components = components
                    .Where(x => x is ISavedComponent)
                    .Cast<ISavedComponent>()
                    .ToList()
            };
        }
    }
}