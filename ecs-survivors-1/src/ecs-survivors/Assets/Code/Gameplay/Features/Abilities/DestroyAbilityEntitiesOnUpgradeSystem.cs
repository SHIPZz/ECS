using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _abilities;
        private readonly GameContext _game;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
        {
            _game = game;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AbilityTypeId,
                    GameMatcher.RecreatedOnUpdate
                ));
                
                
            _upgradeRequests = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityTypeId));
        }

        public void Execute()
        {
            foreach (GameEntity upgradeRequest in _upgradeRequests)
            foreach (GameEntity ability in _abilities)
            {
                if (upgradeRequest.AbilityTypeId == ability.AbilityTypeId)
                {
                    foreach (GameEntity entity in _game.GetEntitiesWithParentAbility(ability.AbilityTypeId))
                        entity.isDestructed = true;

                    ability.isActive = false;
                }
            }
        }
    }
}