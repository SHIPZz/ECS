using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class CleanupAchievementTimerSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _achievementTimer;
        private readonly List<MetaEntity> _buffer = new(1);

        public CleanupAchievementTimerSystem(MetaContext meta)
        {
            _achievementTimer = meta.GetGroup(MetaMatcher.AchievementTimer);
        }

        public void Cleanup()
        {
            foreach (MetaEntity achievementTimer in _achievementTimer.GetEntities(_buffer))
            {
                achievementTimer.Destroy();
            }
        }
    }
}