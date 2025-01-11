﻿using UnityEngine;

namespace Code.Infrastructure.View.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;
        
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