using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Windows;
using Code.States.StateInfrastructure;
using Resources.Gameplay.Windows;

namespace Code.States.GameStates
{
    public class GameOverState : SimpleState
    {
        private readonly IWindowService _windowService;
        private IAbilityUpgradeService _abilityUpgradeService;

        public GameOverState(IWindowService windowService, IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
            _windowService = windowService;
        }

        public override void Enter()
        {
            _windowService.Open(WindowId.GameOverWindow);
            _abilityUpgradeService.Cleanup();
        }
    }
}