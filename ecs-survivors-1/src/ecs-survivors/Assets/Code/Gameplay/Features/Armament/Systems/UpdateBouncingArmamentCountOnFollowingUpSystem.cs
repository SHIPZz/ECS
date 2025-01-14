using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class UpdateBouncingArmamentCountOnFollowingUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public UpdateBouncingArmamentCountOnFollowingUpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BouncingArmament,
                    GameMatcher.BouncingCount,
                    GameMatcher.FollowingUp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceBouncingCount(entity.BouncingCount + 1);
            }
        }
    }
}