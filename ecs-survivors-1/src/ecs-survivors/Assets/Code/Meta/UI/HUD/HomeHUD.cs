using Code.Gameplay.Windows;
using Code.States.GameStates;
using Code.States.StateMachine;
using Resources.Gameplay.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD
{
  public class HomeHUD : MonoBehaviour
  {
    private const string BattleSceneName = "Meadow";
    
    private IGameStateMachine _stateMachine;

    public Button StartBattleButton;
    public Button ShopButton;
    private IWindowService _windowService;

    [Inject]
    private void Construct(IGameStateMachine gameStateMachine, IWindowService windowService)
    {
      _windowService = windowService;
      _stateMachine = gameStateMachine;
    }

    private void Awake()
    {
      StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
      ShopButton.onClick.AddListener(OpenShopWindow);
    }

    private void OpenShopWindow()
    {
      _windowService.Open(WindowId.ShopWindow);
    }

    private void EnterBattleLoadingState() => 
      _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
  }
}