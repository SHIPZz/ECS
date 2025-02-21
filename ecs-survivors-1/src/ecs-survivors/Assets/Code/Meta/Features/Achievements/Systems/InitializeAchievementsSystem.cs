using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using Code.Meta.Features.Achievements.Services;
using Code.Meta.SaveLoad;
using Entitas;
using UnityEngine;

namespace Code.Meta.Features.Achievements.Systems
{
    public class InitializeAchievementsSystem : IInitializeSystem
    {
        private readonly IAchievementService _achievementService;
        private readonly IIdentifierService _identifierService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly MetaContext _meta;

        public InitializeAchievementsSystem(IAchievementService achievementService,
            IIdentifierService identifierService,
            MetaContext meta,
            ISaveLoadService saveLoadService)
        {
            _meta = meta;
            _saveLoadService = saveLoadService;
            _identifierService = identifierService;
            _achievementService = achievementService;
        }

        public void Initialize()
        {
            _achievementService.InitializeAchievements();

            if (_saveLoadService.HasSavedProgress && _meta.GetGroup(MetaMatcher.Achievement).count > 0)
            {
                ActualizeAchievements();

                return;
            }

            //todo refactor:

            CreateEntity
                .Empty()
                .AddEnemyDeadCount(99);

            CreateGoldCollectAchievement();
            CreateKillEnemyAchievement();
        }

        private void ActualizeAchievements()
        {
            var achievements = _meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.Achievement,
                    MetaMatcher.AchievementTypeId,
                    MetaMatcher.CurrentAmount));

            foreach (MetaEntity achievement in achievements)
            {
                _achievementService.UpdateAchievement(achievement.AchievementTypeId, achievement.CurrentAmount);
            }
        }

        private MetaEntity CreateGoldCollectAchievement()
        {
            AchievementProgress achievementProgress =
                _achievementService.GetAchievementProgress(AchievementTypeId.Gold);

            return CreateAchievementEntity(achievementProgress)
                    .With(x => x.isGoldCollectAchievement = true)
                ;
        }

        private MetaEntity CreateKillEnemyAchievement()
        {
            AchievementProgress achievementProgress =
                _achievementService.GetAchievementProgress(AchievementTypeId.KillEnemy);

            return CreateAchievementEntity(achievementProgress)
                    .With(x => x.isKillEnemyAchievement = true)
                ;
        }

        private MetaEntity CreateAchievementEntity(AchievementProgress achievementProgress)
        {
            return CreateMetaEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddAchievementTypeId(achievementProgress.Id)
                    .AddCurrentAmount(achievementProgress.CurrentValue)
                    .AddTargetAmount(achievementProgress.TargetAmount)
                    .With(x => x.isAchievement = true)
                ;
        }
    }
}