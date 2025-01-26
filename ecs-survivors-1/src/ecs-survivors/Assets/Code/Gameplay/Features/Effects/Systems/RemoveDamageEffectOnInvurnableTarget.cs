using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class RemoveDamageEffectOnInvurnableTarget : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public RemoveDamageEffectOnInvurnableTarget(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetId,
                    GameMatcher.EffectValue,
                    GameMatcher.DamageEffect
                ));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects.GetEntities(_buffer))
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;

                if (target.isInvulnerable)
                {
                    effect.RemoveEffectValue();
                }
            }
        }
    }
}