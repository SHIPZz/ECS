using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Services
{
    public interface IGetClosestEnemyService
    {
        GameEntity GetClosestEnemy(GameEntity entity, IGroup<GameEntity> enemies);
    }
}