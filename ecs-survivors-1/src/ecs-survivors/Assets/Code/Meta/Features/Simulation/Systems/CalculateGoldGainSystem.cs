using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class CalculateGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _storages;
        private readonly IStaticDataService _staticDataService;

        public CalculateGoldGainSystem(MetaContext meta, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _storages = meta.GetGroup(MetaMatcher
                .AllOf(
                MetaMatcher.Storage,
                MetaMatcher.GoldPerSecond
                ));

            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
        }

        public void Execute()
        {
            foreach (MetaEntity storage in _storages)
            {
                float gainBonus = 1;

                foreach (MetaEntity booster in _boosters) 
                    gainBonus += booster.GoldGainBoost;

                storage.ReplaceGoldPerSecond(_staticDataService.AfkGainConfig.GoldPerSecond * gainBonus);
            }
        }
    }
}