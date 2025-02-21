using Code.Gameplay.Features;
using Code.Infrastructure.Systems;
using Code.States.StateInfrastructure;

namespace Code.States.GameStates
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systemFactory;
        private BattleFeature _battleFeature;
        private readonly GameContext _game;

        public BattleLoopState(ISystemFactory systemFactory, GameContext game)
        {
            _game = game;
            _systemFactory = systemFactory;
        }

        public override void Enter()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
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
                if (!entity.isDontDestroyOnGameOver)
                    entity.isDestructed = true;
            }
        }
    }
}