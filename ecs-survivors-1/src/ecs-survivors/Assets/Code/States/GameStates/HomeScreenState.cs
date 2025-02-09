using Code.Infrastructure.Systems;
using Code.Meta.UI;
using Code.States.StateInfrastructure;

namespace Code.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemFactory;
        private HomeScreenFeature _homeScreenFeature;
        private readonly GameContext _game;

        public HomeScreenState(ISystemFactory systemFactory, GameContext game)
        {
            _game = game;
            _systemFactory = systemFactory;
        }

        public void Enter()
        {
            _homeScreenFeature = _systemFactory.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        public void Update()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        public void Exit()
        {
            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();

            DestructEntities();

            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
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