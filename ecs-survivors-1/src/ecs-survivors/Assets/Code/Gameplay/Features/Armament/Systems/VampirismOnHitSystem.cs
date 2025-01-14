using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class VampirismOnHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _vampires;
        private readonly IGroup<GameEntity> _targets;

        public VampirismOnHitSystem(GameContext game)
        {
            _game = game;

            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.VampirismArmament,
                    GameMatcher.LastCollectedId,
                    GameMatcher.ArmamentProducerId,
                    GameMatcher.Damage,
                    GameMatcher.Collected
                    ));

            _targets = game.GetGroup(GameMatcher.AllOf( GameMatcher.Id, GameMatcher.VampireId));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                GameEntity armamentProducer = _game.GetEntityWithId(armament.ArmamentProducerId);

                if(!_targets.ContainsEntity(armamentProducer))
                    continue;

                armamentProducer.AddRestoreHp(armament.Damage);
            }
        }
    }
}