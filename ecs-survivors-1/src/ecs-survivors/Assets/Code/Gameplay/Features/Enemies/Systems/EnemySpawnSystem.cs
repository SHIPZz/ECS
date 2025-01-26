using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private const float SpawnDistanceGap = 0.4f;
        
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICameraProvider _cameraProvider;
        private int _spawnToggle;

        public EnemySpawnSystem(GameContext game, ITimeService timeService, IEnemyFactory enemyFactory, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _enemyFactory = enemyFactory;
            _timeService = timeService;

            _heroes = game.GetGroup(GameMatcher.Hero);
            
            _timers = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.SpawnTimer));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);

                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(1f);

                    _enemyFactory.CreateEnemy(EnemyTypeId.Goblin,
                        RandomSpawnPosition(hero.WorldPosition));

                    _spawnToggle++; 
                }
            }
        }
        
        private Vector2 RandomSpawnPosition(Vector2 aroundPosition)
        {
            var startWithHorizontal = Random.Range(0, 2) == 0;

            return startWithHorizontal
                ? HorizontalSpawnPosition(aroundPosition)
                : VerticalSpawnPosition(aroundPosition);
        }

        private Vector2 HorizontalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
            var primaryDirection = horizontalDirections.PickRandom();

            var horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SpawnDistanceGap;
            var verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

            return aroundPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
        }


        private Vector2 VerticalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] verticalDirections = { Vector2.up, Vector2.down };
            var primaryDirection = verticalDirections.PickRandom();

            var verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SpawnDistanceGap;
            var horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

            return aroundPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
        }
    }
}