using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class ProvokeBleedingOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;

        public ProvokeBleedingOnHitSystem(GameContext game)
        {
            _game = game;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.BleedingProvocateurArmament,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            {
                GameEntity target = _game.GetEntityWithId(targetId);

                if (target.isBleedingAvailable)
                {
                    target.isBleedingRequested = true;
                    target.isBleeding = true;
                }
            }
        }
    }
}