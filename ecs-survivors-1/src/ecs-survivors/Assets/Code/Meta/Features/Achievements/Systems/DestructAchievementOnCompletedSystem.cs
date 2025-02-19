using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class CleanupAchievementOnCompletedSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _entities;

        public CleanupAchievementOnCompletedSystem(MetaContext meta)
        {
            _entities = meta.GetGroup(MetaMatcher.AllOf(MetaMatcher.AchievementTypeId, MetaMatcher.Completed));
        }

        public void Cleanup()
        {
            foreach (MetaEntity entity in _entities)
            {
                entity.isDestructed = true;
            }
        }
    }
}