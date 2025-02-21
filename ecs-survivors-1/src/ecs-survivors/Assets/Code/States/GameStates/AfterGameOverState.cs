using Code.States.StateInfrastructure;
using Code.States.StateMachine;

namespace Code.States.GameStates
{
    public class AfterGameOverState : SimpleState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly GameContext _game;

        public AfterGameOverState(IGameStateMachine gameStateMachine, GameContext game)
        {
            _gameStateMachine = gameStateMachine;
            _game = game;
        }

        public override void Enter()
        {
            DestroyEntities();
            
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }

        private void DestroyEntities()
        {
            foreach (GameEntity entity in _game.GetEntities())
            {
                entity.isDestructed = true;
            }
        }
    }
}