using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Services
{
    public class GetClosestEnemyService : IGetClosestEnemyService
    {
        public GameEntity GetClosestEnemy(GameEntity entity, IGroup<GameEntity> enemies)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            foreach (GameEntity enemy in enemies)
            {
                float distanceToTarget = Vector3.Distance(enemy.WorldPosition, entity.WorldPosition);

                if (distanceToTarget <= maxDistance)
                {
                    maxDistance = distanceToTarget;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}