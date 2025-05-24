using System.Collections.Generic;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public sealed class DetermineBleedTrailSpawnRequestSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _deadEnemies;
        private readonly List<GameEntity> _buffer = new(32);

        private const float ThresholdN = 1.0f; 
        private const float ThresholdK = 2.0f; 
        private const float ThresholdJ = 3.0f; 

        public DetermineBleedTrailSpawnRequestSystem(GameContext game)
        {
            _gameContext = game;
            _deadEnemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy,
                GameMatcher.Dead,
                GameMatcher.WorldPosition,
                GameMatcher.PreviousWorldPosition,
                GameMatcher.BleedingTrails,
                GameMatcher.BleedingTrailSpawnAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _deadEnemies.GetEntities(_buffer))
            {
                Vector3 currentPosition = enemy.WorldPosition;
                Vector3 previousPosition = enemy.PreviousWorldPosition;

                float movementDelta = Vector3.Distance(currentPosition, previousPosition);

                BleedingTrailTypeId trailTypeId = GetBleedingTrailTypeByMovementDelta(movementDelta); 
                
                CreateBloodTrailRequest(trailTypeId, currentPosition, enemy);

                enemy.isBleedingTrailSpawnAvailable = false;
                enemy.ReplaceLastBleedTrailSpawnTime(Time.time);
            }
        }

        private static BleedingTrailTypeId GetBleedingTrailTypeByMovementDelta(float movementDelta)
        {
            BleedingTrailTypeId trailTypeId = BleedingTrailTypeId.Splash;
            
            switch (movementDelta)
            {
                case > ThresholdJ:
                    trailTypeId = BleedingTrailTypeId.Splash;
                    break;
                case > ThresholdK:
                    trailTypeId = BleedingTrailTypeId.Splash;
                    break;
                case > ThresholdN:
                    trailTypeId = BleedingTrailTypeId.Long;
                    break;
            }

            return trailTypeId;
        }

        private void CreateBloodTrailRequest(BleedingTrailTypeId trailTypeId, Vector3 currentPosition, GameEntity enemy)
        {
            GameEntity requestEntity = _gameContext.CreateEntity();
            BloodTrailRequest request = new BloodTrailRequest(trailTypeId, currentPosition, Quaternion.identity,enemy.BleedingTrails);
            requestEntity.AddBloodTrailRequest(request);
        }
    }
}