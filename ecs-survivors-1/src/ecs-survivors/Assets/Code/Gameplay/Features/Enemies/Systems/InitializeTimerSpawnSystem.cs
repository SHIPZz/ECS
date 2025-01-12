using Code.Common;
using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class InitializeTimerSpawnSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity
                .Empty()
                .AddSpawnTimer(GameplayConstants.EnemySpawnTime);
        }
    }
}