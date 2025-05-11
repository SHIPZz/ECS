using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class CleanupBleedTrailSpawnListSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _bleedSpawners;

        public CleanupBleedTrailSpawnListSystem(GameContext game)
        {
            _bleedSpawners = game.GetGroup(GameMatcher.BleedSpawnList);
        }

        public void Cleanup()
        {
            foreach (GameEntity bleedSpawner in _bleedSpawners)
            {
                bleedSpawner.BleedSpawnList.Clear();
            }
        }
    }
}