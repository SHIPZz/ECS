using System.Collections.Generic;
using System.Linq;
using Code.Meta.UI.GoldHolders.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolders.Systems
{
    public class RefreshGoldGainBoostSystem : ReactiveSystem<MetaEntity>, IInitializeSystem
    {
        private readonly IStorageUIService _storage;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly List<MetaEntity> _boostersBuffer = new(5);

        public RefreshGoldGainBoostSystem(IContext<MetaEntity> meta, IStorageUIService storage) : base(meta)
        {
            _storage = storage;
            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
        }

        public void Initialize()
        {
            UpdateGoldGainBoost(_boosters.GetEntities(_boostersBuffer));
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context) =>
            context.CreateCollector(MetaMatcher.GoldGainBoost.AddedOrRemoved());

        protected override bool Filter(MetaEntity entity) => true;

        protected override void Execute(List<MetaEntity> entities)
        {
            UpdateGoldGainBoost(entities);
        }

        private void UpdateGoldGainBoost(List<MetaEntity> entities)
        {
            float goldGainBoost = 0f;

            foreach (MetaEntity booster in entities)
                if (booster.hasGoldGainBoost)
                    goldGainBoost += booster.GoldGainBoost;

            _storage.UpdateGoldGainBoost(goldGainBoost);
        }
    }
}