using Code.Common.Extensions;
using Code.Gameplay.Common.Position;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems.EnemySpawn
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGroup<GameEntity> _enemyWaves;
        private readonly IGetRandomPositionService _getRandomPositionService;

        public EnemySpawnSystem(GameContext game,
            IEnemyFactory enemyFactory,
            IGetRandomPositionService getRandomPositionService
        )
        {
            _getRandomPositionService = getRandomPositionService;
            _enemyFactory = enemyFactory;

            _heroes = game.GetGroup(GameMatcher.Hero);

            _enemyWaves = game.GetGroup(GameMatcher.AllOf(GameMatcher.EnemyWave, GameMatcher.EnemySpawnAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity enemyWave in _enemyWaves)
            {
                int enemyWaveEnemySpawnCount = enemyWave.EnemySpawnCount;

                for (int i = 0; i < enemyWaveEnemySpawnCount; i++)
                {
                    _enemyFactory.CreateEnemy(enemyWave.EnemySpawnIds.PickRandom(), _getRandomPositionService.RandomPosition(hero.WorldPosition));
                }
            }
        }
    }
}