using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Enemies.Services;
using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class ProcessMagnificentBoltOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _magnificentBolt;
        private readonly IGetClosestEntityService _getClosestEntityService;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IArmamentFactory _armamentFactory;
        private readonly List<int> _targetedEnemies = new();
        private GameContext _game;

        public ProcessMagnificentBoltOnHitSystem(GameContext game,
            IGetClosestEntityService getClosestEntityService,
            IArmamentFactory armamentFactory)
        {
            _game = game;
            _armamentFactory = armamentFactory;
            _getClosestEntityService = getClosestEntityService;

            _magnificentBolt = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.MagnificentBoltArmament,
                    GameMatcher.LastCollectedId,
                    GameMatcher.AdditionalProjectileCount
                ));

            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Alive,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _magnificentBolt)
            {
                if(_enemies.count < armament.AdditionalProjectileCount)
                    continue;

                _targetedEnemies.Clear();
                _targetedEnemies.Add(armament.LastCollectedId);

                int maxProjectiles = armament.AdditionalProjectileCount;
                int createdProjectiles = 0;
                
                while (createdProjectiles < maxProjectiles)
                {
                    GameEntity closestEnemy = _getClosestEntityService.GetClosestEntity(armament, _enemies, _targetedEnemies);
                    
                    if (closestEnemy == null)
                        break;
                    
                    _targetedEnemies.Add(closestEnemy.Id);

                    _armamentFactory.CreatePullBolt(1, armament.WorldPosition)
                        .With(x => x.AddFollowTargetId(closestEnemy.Id))
                        .With(x => x.isMoving = true)
                        .With(x => x.IgnoreBuffer.Add(armament.LastCollectedId))
                        .With(x => x.isMovingAvailable = true)
                        ;

                    createdProjectiles++;
                }
            }
        }
    }
}