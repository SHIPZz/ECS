using Code.Meta.Features.Achievements.Services;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class UpdateKillEnemyAchievementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemyDeadCounter;
        private readonly IAchievementService _achievementService;
        private readonly IGroup<MetaEntity> _tick;
        private readonly IGroup<MetaEntity> _enemyKillAchievement;

        public UpdateKillEnemyAchievementSystem(GameContext game, MetaContext meta, IAchievementService achievementService)
        {
            _achievementService = achievementService;
            
            _tick = meta.GetGroup(MetaMatcher.Tick);
            _enemyKillAchievement = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.KillEnemyAchievement, 
                MetaMatcher.CurrentAmount));
            
            _enemyDeadCounter = game.GetGroup(GameMatcher.EnemyDeadCount);
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (GameEntity enemyDeadCounter in _enemyDeadCounter)
            foreach (MetaEntity enemyKillAchievement in _enemyKillAchievement)
            {
                _achievementService.UpdateAchievement(AchievementTypeId.KillEnemy, enemyDeadCounter.EnemyDeadCount);
                enemyKillAchievement.ReplaceCurrentAmount(enemyDeadCounter.EnemyDeadCount);
            }
        }
    }

}