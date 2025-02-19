using Code.Infrastructure.Systems;
using Code.Meta.Features.Achievements.Systems;

namespace Code.Meta.Features.Achievements
{
    public sealed class AchievementFeature : Feature
    {
        public AchievementFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeAchievementsSystem>());
            
            Add(systems.Create<UpdateGoldCollectAchievementSystem>());
            
            Add(systems.Create<CleanupAchievementOnCompletedSystem>());
        }
    }
}