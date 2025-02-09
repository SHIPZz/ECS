using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Simulation.Roll
{
    public class CleanUpRollSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _rollTimers;
        private readonly IGroup<MetaEntity> _rolls;
        private readonly List<MetaEntity> _buffer = new(2);
        private readonly List<MetaEntity> _rollTimerBuffer = new(2);

        public CleanUpRollSystem(MetaContext meta)
        {
            _rollTimers = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.RollTimeUp,
                    MetaMatcher.RollTimeLeft,
                    MetaMatcher.RollTime
                ));
            
            _rolls = meta.GetGroup(MetaMatcher.AllOf(MetaMatcher.Roll));
        }

        public void Cleanup()
        {
            foreach (MetaEntity rollTimer in _rollTimers.GetEntities(_rollTimerBuffer))
            foreach (MetaEntity roll in _rolls.GetEntities(_buffer))
            {
                roll.isDestructed = true;
                rollTimer.isRollTimeUp = false;
            }
        }
    }
}