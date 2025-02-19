using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Infrastructure.Identifiers;
using Code.Meta.Features.Achievements.Services;
using Code.Meta.SaveLoad;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class InitializeAchievementsSystem : IInitializeSystem
    {
        private readonly IAchievementService _achievementService;
        private readonly IIdentifierService _identifierService;
        private ISaveLoadService _saveLoadService;

        public InitializeAchievementsSystem(IAchievementService achievementService, 
            IIdentifierService identifierService,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _identifierService = identifierService;
            _achievementService = achievementService;
        }

        public void Initialize()
        {
            _achievementService.InitializeAchievements();

            if(_saveLoadService.HasSavedProgress)
                return;

            CreateEntity
                .Empty()
                .AddEnemyDeadCount(99);
            
            InitGoldCollectAchievement();
            InitKillEnemyAchievement();
        }

        private void InitGoldCollectAchievement()
        {
            AchievementProgress achievementProgress = _achievementService.GetAchievementProgress(AchievementTypeId.Gold);
            
            CreateAchievementEntity(achievementProgress)
                .With(x => x.isGoldCollectAchievement = true)
                ;
        }
        
        private void InitKillEnemyAchievement()
        {
            AchievementProgress achievementProgress = _achievementService.GetAchievementProgress(AchievementTypeId.KillEnemy);
            
            CreateAchievementEntity(achievementProgress)
                .With(x => x.isKillEnemyAchievement = true)
                ;
        }

        private MetaEntity CreateAchievementEntity(AchievementProgress achievementProgress)
        {
            return CreateMetaEntity.Empty()
                .AddId(_identifierService.Next())
                .AddAchievementTypeId(achievementProgress.Config.Id)
                .AddCurrentAmount(achievementProgress.CurrentValue)
                .AddTargetAmount(achievementProgress.TargetAmount);
        }
    }
}