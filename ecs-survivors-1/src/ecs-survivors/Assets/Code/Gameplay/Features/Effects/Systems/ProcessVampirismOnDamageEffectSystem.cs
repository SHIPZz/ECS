using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessVampirismOnDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageEffects;
        private readonly IGroup<GameEntity> _vampireStatuses;
        private readonly GameContext _game;

        public ProcessVampirismOnDamageEffectSystem(GameContext game)
        {
            _game = game;
            
            _damageEffects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetId,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.DamageEffect
                ));

            _vampireStatuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProducerId,
                    GameMatcher.Vampirism,
                    GameMatcher.Status
                ));
        }

        public void Execute()
        {
            foreach (GameEntity vampireStatus in _vampireStatuses)
            foreach (GameEntity damageEffect in _damageEffects)
            {
                if (vampireStatus.ProducerId != damageEffect.ProducerId)
                    continue;

                GameEntity producer = _game.GetEntityWithId(vampireStatus.ProducerId);

                producer.ReplaceCurrentHp(producer.CurrentHp + damageEffect.EffectValue);
            }
        }
    }
}