using Code.Infrastructure.Systems;
using Code.Meta.UI;
using Code.Meta.UI.Shop;
using Code.States.StateInfrastructure;

namespace Code.States.GameStates
{
    public class HomeScreenState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systemFactory;
        private readonly GameContext _game;
        private readonly IShopUIService _shopUIService;

        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(ISystemFactory systemFactory, GameContext game, IShopUIService shopUIService)
        {
            _shopUIService = shopUIService;
            _game = game;
            _systemFactory = systemFactory;
        }

        public override void Enter()
        {
            _homeScreenFeature = _systemFactory.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        protected override void ExitOnEndOfFrame()
        {
            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();

            DestructEntities();

            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
            _shopUIService.Cleanup();
        }

        protected override void OnUpdate()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _game.GetEntities())
            {
                entity.isDestructed = true;
            }
        }
    }
}