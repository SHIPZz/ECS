using Code.Meta.Features.Achievements.Services;
using Entitas;

namespace Code.Meta.Features.Achievements.Systems
{
    public class UpdateKillEnemyAchievementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemyDeadCounter;
        private readonly IAchievementService _achievementService;
        private readonly IGroup<MetaEntity> _tick;

        public UpdateKillEnemyAchievementSystem(GameContext game, MetaContext meta, IAchievementService achievementService)
        {
            _achievementService = achievementService;
            _tick = meta.GetGroup(MetaMatcher.Tick);
            _enemyDeadCounter = game.GetGroup(GameMatcher.EnemyDeadCount);
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (GameEntity enemyDeadCounter in _enemyDeadCounter)
            {
                _achievementService.UpdateAchievement(AchievementTypeId.KillEnemy, enemyDeadCounter.EnemyDeadCount);
            }
        }
    }

}