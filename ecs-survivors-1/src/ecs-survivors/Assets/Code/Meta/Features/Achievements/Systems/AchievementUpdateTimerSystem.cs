using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;

namespace Code.Meta.Features.Achievements.Systems
{
    public class AchievementUpdateTimerSystem : TimerExecuteSystem
    {
        private readonly float _executeIntervalSeconds;

        public AchievementUpdateTimerSystem(float executeIntervalSeconds, ITimeService time) : base(
            executeIntervalSeconds, time)
        {
            _executeIntervalSeconds = executeIntervalSeconds;
        }
        
        protected override void Execute()
        {
            CreateMetaEntity
                .Empty()
                .With(x => x.isUpdateAchievementAvailable = true)
                .AddAchievementTimer(_executeIntervalSeconds);
        }
    }
}