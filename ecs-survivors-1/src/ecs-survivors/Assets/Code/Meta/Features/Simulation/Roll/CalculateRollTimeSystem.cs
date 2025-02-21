using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Simulation.Roll
{
    public class CalculateRollTimeSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _entities;
        private readonly IGroup<MetaEntity> _tick;
        private readonly List<MetaEntity> _buffer = new(2);

        public CalculateRollTimeSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);
            
            _entities = meta.GetGroup(MetaMatcher
                .AllOf(
                    MetaMatcher.RollTime,
                    MetaMatcher.RollTimeLeft
                    ).NoneOf(MetaMatcher.RollTimeUp));
        }

        public void Execute()
        {
            foreach (MetaEntity tick in _tick)
            foreach (MetaEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceRollTimeLeft(entity.RollTimeLeft - tick.Tick);

                if (entity.RollTimeLeft <= 0)
                {
                    entity.ReplaceRollTimeLeft(entity.RollTime);
                    entity.isRollTimeUp = true;
                }
            }
        }
    }
}