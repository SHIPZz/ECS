using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace Code.Gameplay.Features.LevelUp
{
    public class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _requests;
        private readonly IGroup<GameEntity> _levelUps;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public UpgradeAbilityOnRequestSystem(GameContext game, IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
            _levelUps = game.GetGroup(GameMatcher.LevelUp);

            _requests = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AbilityTypeId,
                    GameMatcher.UpgradeRequest
                ));
        }

        public void Execute()
        {
            foreach (GameEntity request in _requests)
            foreach (GameEntity levelUp in _levelUps)
            {
                _abilityUpgradeService.UpgradeAbility(request.AbilityTypeId);

                levelUp.isProcessed = true;
                request.isDestructed = true;
            }
        }
    }
}