using Sirenix.OdinInspector;

namespace Code.Infrastructure.View.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        [Button]
        private void GetSpriteRenderer()
        {
            EntityView = GetComponent<EntityBehaviour>();
        }
        
        public override void RegisterComponents()
        {
            Entity.AddTransform(transform);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasTransform)
                Entity.RemoveTransform();
        }
    }
}