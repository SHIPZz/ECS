using Code.Infrastructure.Loading;
using Code.States.StateInfrastructure;
using Code.States.StateMachine;

namespace Code.States.GameStates
{
  public class LoadingHomeScreenState : SimpleState
  {
    private const string HomeScreenSceneName = "HomeScreen";
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public override void Enter()
    {
      _sceneLoader.LoadScene(HomeScreenSceneName, EnterHomeScreenState);
    }

    private void EnterHomeScreenState()
    {
      _stateMachine.Enter<HomeScreenState>();
    }
  }
}