using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class AnimateHeroOnMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public AnimateHeroOnMovementSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.HeroAnimator
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if(hero.isMoving)
                    hero.HeroAnimator.PlayMove();
                else
                    hero.HeroAnimator.PlayIdle();
            }
        }
    }
}