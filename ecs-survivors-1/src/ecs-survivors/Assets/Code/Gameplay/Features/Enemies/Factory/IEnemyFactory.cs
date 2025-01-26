using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at);
    }
}