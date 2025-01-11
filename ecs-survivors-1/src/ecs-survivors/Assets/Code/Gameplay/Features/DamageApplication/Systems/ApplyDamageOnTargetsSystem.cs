using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageDealers;
        private GameContext _game;

        public ApplyDamageOnTargetsSystem(GameContext game)
        {
            _game = game;

            _damageDealers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.Damage
                ));
        }

        public void Execute()
        {
            foreach (GameEntity damageDealer in _damageDealers)
            {
                foreach (int targetId in damageDealer.TargetsBuffer)
                {
                    GameEntity target = _game.GetEntityWithId(targetId);

                    if (!target.hasCurrentHp)
                        continue;
                    
                    target.ReplaceCurrentHp(target.CurrentHp - damageDealer.Damage);

                    if (target.hasDamageTakenAnimator)
                        target.DamageTakenAnimator.PlayDamageTaken();
                }
            }
        }
    }
}