using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class CalculateEnergyGainSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<MetaEntity> _energyStorage;

        public CalculateEnergyGainSystem(MetaContext meta, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;

            _energyStorage = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.Storage,
                    MetaMatcher.AppearChance,
                    MetaMatcher.Energy
                ));
        }

        public void Execute()
        {
            foreach (MetaEntity energy in _energyStorage)
            {
                energy.ReplaceEnergyPerRoll(_staticDataService.AfkGainConfig.EnergyPerRoll);
            }
        }
    }
}