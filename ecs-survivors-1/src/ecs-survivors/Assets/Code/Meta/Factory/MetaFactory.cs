using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Meta.Features.Simulation.Roll;

namespace Code.Meta.Factory
{
    public class MetaFactory : IMetaFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly RollConfig _rollConfig;

        public MetaFactory(IStaticDataService staticDataService, RollConfig rollConfig)
        {
            _rollConfig = rollConfig;
            _staticDataService = staticDataService;
        }

        public MetaEntity CreateRollTimer()
        {
            return CreateMetaEntity
                    .Empty()
                    .AddRollTime(_rollConfig.RollTime)
                    .AddRollTimeLeft(_rollConfig.RollTime)
                ;

        }
        
        public MetaEntity CreateEnergy()
        {
            return  CreateMetaEntity
                    .Empty()
                    .AddEnergy(0)
                    .With(x => x.isStorage = true)
                    .AddAppearChance(_staticDataService.AfkGainConfig.EnergyChance)
                    .AddEnergyPerRoll(_staticDataService.AfkGainConfig.EnergyPerRoll)
                ;
        }

        public MetaEntity CreateGold()
        {
          return  CreateMetaEntity
                .Empty()
                .AddGold(0)
                .With(x => x.isStorage = true)
                .AddGoldPerSecond(_staticDataService.AfkGainConfig.GoldPerSecond)
                ;
        }
    }
}