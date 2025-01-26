using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Services
{
    public interface IGetClosestEntityService
    {
        GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies);
        GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies, int skipId);
        GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies, List<int> skipIds);
    }
}