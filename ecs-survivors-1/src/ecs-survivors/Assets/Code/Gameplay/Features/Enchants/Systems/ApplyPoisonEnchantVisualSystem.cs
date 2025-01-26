using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class ApplyPoisonEnchantVisualSystem : ReactiveSystem<GameEntity>
    {
        public ApplyPoisonEnchantVisualSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.EnchantVisuals,
                    GameMatcher.Armament,
                    GameMatcher.PoisonEnchant
                ).Added());

        protected override bool Filter(GameEntity armament) => armament.isArmament && armament.hasEnchantVisuals;

        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (GameEntity armament in armaments)
            {
                armament.EnchantVisuals.ApplyPoison();
            }
        }
    }
}