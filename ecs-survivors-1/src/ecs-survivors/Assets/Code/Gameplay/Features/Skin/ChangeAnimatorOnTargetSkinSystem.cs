using Entitas;

namespace Code.Gameplay.Features.Skin
{
    public class ChangeAnimatorOnTargetSkinSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ChangeAnimatorOnTargetSkinSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EnemyAnimator,
                    GameMatcher.NewSkinAnimator,
                    GameMatcher.TargetSprite
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.EnemyAnimator.Animator.runtimeAnimatorController != entity.NewSkinAnimator)
                    entity.EnemyAnimator.Animator.runtimeAnimatorController = entity.NewSkinAnimator;
            }
        }
    }
}