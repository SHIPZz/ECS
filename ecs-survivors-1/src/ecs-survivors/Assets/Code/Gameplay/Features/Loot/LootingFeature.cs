using Code.Gameplay.Features.LevelUp.Systems;
using Code.Gameplay.Features.Loot.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Loot
{
    public sealed class LootingFeature : Feature
    {
        public LootingFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForPullableSystem>());
            Add(systems.Create<PullTowardsHeroSystem>());
            Add(systems.Create<CollectWhenNearSystem>());
            
            Add(systems.Create<CollectExperienceSystem>());
            Add(systems.Create<CollectStatusItemSystem>());
            Add(systems.Create<CollectEffectItemSystem>());
            
            Add(systems.Create<UpdateExperienceMeterSystem>());

            Add(systems.Create<CleanupCollectedSystem>());
        }
    }
}