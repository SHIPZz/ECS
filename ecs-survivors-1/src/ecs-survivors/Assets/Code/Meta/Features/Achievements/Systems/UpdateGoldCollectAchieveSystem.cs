using Code.Meta.Features.Achievements.Services;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class UpdateGoldCollectAchievementSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _golds;
        private readonly IAchievementService _achievementService;

        public UpdateGoldCollectAchievementSystem(MetaContext meta, IAchievementService achievementService)
        {
            _achievementService = achievementService;
            
            _golds = meta.GetGroup(MetaMatcher.Gold);
        }

        public void Execute()
        {
            foreach (MetaEntity entity in _golds)
            {
                _achievementService.UpdateAchievement(AchievementTypeId.Gold, entity.Gold);
            }
        }
    }
}