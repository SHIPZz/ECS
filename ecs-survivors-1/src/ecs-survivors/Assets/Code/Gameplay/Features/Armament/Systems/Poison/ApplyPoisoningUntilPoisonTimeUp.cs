using Entitas;

namespace Code.Gameplay.Features.Armament.Systems.Poison
{
    public class ApplyPoisoningUntilPoisonTimeUp : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _poisonables;

        public ApplyPoisoningUntilPoisonTimeUp(GameContext game)
        {
            _poisonables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisonTimeLeft,
                    GameMatcher.CurrentHp,
                    GameMatcher.PoisonDamage
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity poisonable in _poisonables)
            {
                poisonable.ReplaceCurrentHp(poisonable.CurrentHp - poisonable.PoisonDamage);
                poisonable.isPoisoned = true;
                
                if (poisonable.hasDamageTakenAnimator)
                    poisonable.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}