using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;

namespace Code.Meta.Features.Simulation.Systems
{
    public class EmitTickSystem : TimerExecuteSystem
    {
        private float _executeIntervalSeconds;

        public EmitTickSystem(float executeIntervalSeconds, ITimeService time) 
            : base(executeIntervalSeconds, time)
        {
            _executeIntervalSeconds = executeIntervalSeconds;
        }
        
        protected override void Execute()
        {
            CreateMetaEntity.Empty()
                .AddTick(_executeIntervalSeconds)
                ;
            
        }
    }
}