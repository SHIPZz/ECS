using Entitas;

namespace Code.Gameplay.Features.Armament.Systems.Poison
{
    public class PutPoisonOnTargetOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private readonly IGroup<GameEntity> _targets;
        private readonly GameContext _game;

        public PutPoisonOnTargetOnHitSystem(GameContext game)
        {
            _game = game;
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PoisonArmament,
                    GameMatcher.Collected,
                    GameMatcher.PoisonDamage,
                    GameMatcher.PoisonTime,
                    GameMatcher.LastCollectedId
                    ));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.CurrentHp, GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                GameEntity target = _game.GetEntityWithId(armament.LastCollectedId);
                
                if(!_targets.ContainsEntity(target) || target.isPoisoned)
                    continue;

                target.PutOnPoison(armament.PoisonTime, armament.PoisonDamage)
                    ;
            }
        }
    }
}