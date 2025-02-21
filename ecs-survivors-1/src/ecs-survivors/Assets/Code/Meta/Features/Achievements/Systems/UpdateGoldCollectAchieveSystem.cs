using Code.Meta.Features.Achievements.Services;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class UpdateGoldCollectAchievementByTickSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _golds;
        private readonly IAchievementService _achievementService;
        private readonly IGroup<MetaEntity> _goldAchievement;
        private readonly IGroup<MetaEntity> _tick;

        public UpdateGoldCollectAchievementByTickSystem(MetaContext meta, IAchievementService achievementService)
        {
            _achievementService = achievementService;

            _golds = meta.GetGroup(MetaMatcher.Gold);
            _tick = meta.GetGroup(MetaMatcher.Tick);

            _goldAchievement = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.AchievementTypeId,
                    MetaMatcher.Achievement,
                    MetaMatcher.CurrentAmount,
                    MetaMatcher.GoldCollectAchievement));
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (MetaEntity gold in _golds)
            foreach (MetaEntity goldCollectAchievement in _goldAchievement)
            {
                _achievementService.UpdateAchievement(AchievementTypeId.Gold, gold.Gold);

                goldCollectAchievement.ReplaceCurrentAmount(gold.Gold);
            }
        }
    }
}