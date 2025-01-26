using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Visuals
{
    public class EnchantVisualsRegistrar : EntityComponentRegistrar
    {
        public EnchantVisuals EnchantVisuals;
        
        public override void RegisterComponents()
        {
            Entity.AddEnchantVisuals(EnchantVisuals);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveEnchantVisuals();
        }
    }
}