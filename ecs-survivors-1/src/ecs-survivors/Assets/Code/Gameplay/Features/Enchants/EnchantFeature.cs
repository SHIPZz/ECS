using Code.Gameplay.Features.Enchants.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Enchants
{
    public sealed class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory systems)
        {
            Add(systems.Create<HexEnchantSystem>());
            Add(systems.Create<PoisonEnchantSystem>());
            Add(systems.Create<ExplosiveEnchantSystem>());
            
            Add(systems.Create<ApplyPoisonEnchantVisualSystem>());
            Add(systems.Create<ApplyEnchantToHolderSystem>());
        }
    }
}