using System;
using System.Collections.Generic;

namespace Code.Meta.Features.Achievements.Services
{
    public interface IAchievementService
    {
        event Action<AchievementTypeId, AchievementConfig> OnAchievementCompleted;
        event Action<AchievementTypeId, float> OnAchievementChanged;
        AchievementsConfig AchievementsConfig { get; }

        void InitializeAchievements();
        
        void UpdateAchievement(AchievementTypeId id, float value);
        
        AchievementProgress GetAchievementProgress(AchievementTypeId id);
        
        float GetAchievementTargetAmount(AchievementTypeId id);
        
        List<AchievementProgress> GetAchievementsProgress(AchievementTypeId id);
        bool HasNext(AchievementTypeId id);
    }
}