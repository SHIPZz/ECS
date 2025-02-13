using Entitas;

namespace Code.Meta.UI.GoldHolders.Behaviours
{
    public class RefreshGoldSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _entities;
        private readonly IStorageUIService _storageUIService;

        public RefreshGoldSystem(MetaContext meta, IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
            
            _entities = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.Gold,
                    MetaMatcher.Storage
                ));
        }

        public void Execute()
        {
            foreach (MetaEntity entity in _entities)
            {
                _storageUIService.UpdateCurrentGold(entity.Gold);
            }
        }
    }
}