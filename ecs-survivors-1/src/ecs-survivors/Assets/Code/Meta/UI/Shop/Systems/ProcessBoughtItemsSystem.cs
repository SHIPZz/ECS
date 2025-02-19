using System.Collections.Generic;
using Code.Meta.SaveLoad;
using Code.Meta.UI.Shop.Factory;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public class ProcessBoughtItemsSystem : ReactiveSystem<MetaEntity>
    {
        private readonly IShopItemFactory _shopItemFactory;
        private readonly ISaveLoadService _saveLoadService;

        public ProcessBoughtItemsSystem(IContext<MetaEntity> meta, IShopItemFactory shopItemFactory, ISaveLoadService saveLoadService) : base(meta)
        {
            _saveLoadService = saveLoadService;
            _shopItemFactory = shopItemFactory;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context) =>
            context.CreateCollector(MetaMatcher.Purchased.Added());

        protected override bool Filter(MetaEntity entity) => entity.hasShopItemId;

        protected override void Execute(List<MetaEntity> entities)
        {
            foreach (MetaEntity purchase in entities) 
                _shopItemFactory.Create(purchase.ShopItemId);
            
            _saveLoadService.SaveProgress();
        }
    }
}