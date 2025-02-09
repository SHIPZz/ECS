using Code.Gameplay.Features;
using Code.Infrastructure.Systems;
using Code.States.StateInfrastructure;

namespace Code.States.GameStates
{
    public class BattleLoopState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemFactory;
        private BattleFeature _battleFeature;
        private readonly GameContext _game;

        public BattleLoopState(ISystemFactory systemFactory, GameContext game)
        {
            _game = game;
            _systemFactory = systemFactory;
        }

        public void Enter()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void Exit()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();
         
            DestructEntities();
            
            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
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