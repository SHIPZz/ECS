using Code.Gameplay.Features.Enchants.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enchants
{
    public sealed class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<HexEnchantSystem>());
            Add(systemses.Create<PoisonEnchantSystem>());
            Add(systemses.Create<ExplosiveEnchantSystem>());
            
            Add(systemses.Create<ApplyPoisonEnchantVisualSystem>());
            Add(systemses.Create<ApplyEnchantToHolderSystem>());
        }
    }
}