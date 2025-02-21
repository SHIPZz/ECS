using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class AfkGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _storages;
        private readonly IGroup<MetaEntity> _tick;

        public AfkGoldGainSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);

            _storages = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.Gold,
                    MetaMatcher.GoldPerSecond,
                    MetaMatcher.Storage));
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (MetaEntity storage in _storages)
            {
                storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
            }
        }
    }
}