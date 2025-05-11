using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Infrastructure.View.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;

        [Button]
        private void GetSpriteRenderer()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            EntityView = GetComponent<EntityBehaviour>();
        }
        
        public override void RegisterComponents()
        {
            Entity.AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasSpriteRenderer)
                Entity.RemoveSpriteRenderer();
        }
    }
}