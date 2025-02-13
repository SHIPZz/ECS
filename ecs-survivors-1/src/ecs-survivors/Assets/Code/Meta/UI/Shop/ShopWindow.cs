using System.Collections;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using Resources.Gameplay.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopWindow : BaseWindow
{
    public Transform ItemsLayout;
    public Button CloseButton;
    public GameObject NoItemsAvailable;
    
    private IWindowService _windowService;

    [Inject]
    private void Construct(IWindowService windowService)
    {
        Id = WindowId.ShopWindow;
        
        _windowService = windowService;
    }

    protected override void Initialize()
    {
        CloseButton.onClick.AddListener(Close);
    }

    protected override void SubscribeUpdates()
    {
        Refresh();
    }

    private void Refresh()
    {
        
    }

    protected override void Cleanup()
    {
        base.Cleanup();
        
        CloseButton.onClick.RemoveListener(Close);
    }

    private void Close()
    {
        _windowService.Close(Id);
    }
}