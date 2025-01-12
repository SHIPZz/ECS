using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageDealers;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _targets;

        public ApplyDamageOnTargetsSystem(GameContext game)
        {
            _game = game;

            _damageDealers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.Damage
                ));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.Id, GameMatcher.CurrentHp));
        }

        public void Execute()
        {
            foreach (GameEntity damageDealer in _damageDealers)
            {
                foreach (int targetId in damageDealer.TargetsBuffer)
                {
                    GameEntity target = _game.GetEntityWithId(targetId);

                    if (!_targets.ContainsEntity(target))
                        continue;
                    
                    target.ReplaceCurrentHp(target.CurrentHp - damageDealer.Damage);

                    if (target.hasDamageTakenAnimator)
                        target.DamageTakenAnimator.PlayDamageTaken();
                }
            }
        }
    }
}