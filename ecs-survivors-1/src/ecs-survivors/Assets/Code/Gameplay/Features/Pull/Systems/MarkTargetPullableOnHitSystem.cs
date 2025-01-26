using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class MarkTargetPullableOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullingArmaments;
        private readonly GameContext _game;

        public MarkTargetPullableOnHitSystem(GameContext game)
        {
            _game = game;
            
            _pullingArmaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.PullingArmament
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _pullingArmaments)
            foreach (int targetId in entity.TargetsBuffer)
            {
                GameEntity target = _game.GetEntityWithId(targetId);

                if(target.isDead || target.isPullTargetHolder)
                    continue;

                target.isPullable = true;
            }
        }
    }
}