using Code.Gameplay.Features.LevelUp.Systems;
using Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Loot
{
    public sealed class LootingFeature : Feature
    {
        public LootingFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<CollectWhenNearSystem>());
            
            Add(systemses.Create<CollectExperienceSystem>());
            Add(systemses.Create<CollectStatusItemSystem>());
            Add(systemses.Create<CollectEffectItemSystem>());
            
            Add(systemses.Create<UpdateExperienceMeterSystem>());

            Add(systemses.Create<CleanupCollectedSystem>());
        }
    }
}