namespace Code.Meta.Features.Achievements.Services
{
    public class AchievementProgress
    {
        public AchievementConfig Config { get; }
        public AchievementTypeId Id { get; }
        public float CurrentValue { get; set; }
        public bool IsCompleted { get; set; }

        public float TargetAmount => Config.TargetAmount;

        public AchievementProgress(AchievementConfig config, AchievementTypeId achievementTypeId)
        {
            Id = achievementTypeId;
            Config = config;
        }
    }
}