using Entitas;
using UnityEngine;

namespace Code.Meta.Features.Simulation.Systems
{
    public class AfkEnergyGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _storages;
        private readonly IGroup<MetaEntity> _roll;

        public AfkEnergyGainSystem(MetaContext meta)
        {
            _roll = meta.GetGroup(MetaMatcher.Roll);

            _storages = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.Energy,
                    MetaMatcher.EnergyPerRoll,
                    MetaMatcher.AppearChance,
                    MetaMatcher.Storage));
        }

        public void Execute()
        {
            foreach (MetaEntity roll in _roll)
            foreach (MetaEntity storage in _storages)
            {
                if (roll.Roll <= storage.AppearChance)
                    storage.ReplaceEnergy(storage.Energy + storage.EnergyPerRoll);
            }
        }
    }
}