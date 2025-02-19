using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolders.Systems;
using Code.Meta.UI.Shop;
using Code.Meta.UI.Shop.Systems;

public sealed class HomeScreenUIFeature : Feature
{
    public HomeScreenUIFeature(ISystemFactory systems)
    {
        Add(systems.Create<InitializePurchasedItemsSystem>());
        
        Add(systems.Create<RefreshGoldGainBoostSystem>());
        Add(systems.Create<RefreshGoldSystem>());
        
        Add(systems.Create<ShopFeature>());
    }
}