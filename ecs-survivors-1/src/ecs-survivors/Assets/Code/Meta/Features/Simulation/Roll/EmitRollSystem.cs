using Code.Common.Entity;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;
using Entitas;
using UnityEngine;

namespace Code.Meta.Features.Simulation.Roll
{
    public class EmitRollSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _rollTimers;
        private readonly IRandomService _randomService;
        private readonly RollConfig _rollConfig;

        public EmitRollSystem(MetaContext meta, IRandomService randomService, RollConfig rollConfig)
        {
            _rollConfig = rollConfig;
            _randomService = randomService;
            _rollTimers = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.RollTimeUp,
                    MetaMatcher.RollTimeLeft,
                    MetaMatcher.RollTime
                ));
        }
        
        public void Execute()
        {
            foreach (MetaEntity rollTimeUp in _rollTimers)
            {
                CreateMetaEntity
                    .Empty()
                    .ReplaceRoll(_randomService.Range(_rollConfig.InclusiveMin, _rollConfig.InclusiveMax));
            }
        }
    }
}