using Code.Meta.Features.Achievements.Services;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class InitializeAchievementsSystem : IInitializeSystem
    {
        private readonly IAchievementService _achievementService;

        public InitializeAchievementsSystem(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        public void Initialize()
        {
            _achievementService.InitializeAchievements();
        }
    }
}