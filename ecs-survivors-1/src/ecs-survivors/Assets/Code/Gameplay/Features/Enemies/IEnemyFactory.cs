using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    public interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector2 at);
    }
}