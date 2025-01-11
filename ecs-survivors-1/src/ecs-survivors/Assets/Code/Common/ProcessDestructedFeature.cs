using Code.Common.Systems.Destruct;
using Code.Gameplay.Features.Movement;

namespace Code.Common
{
    public sealed class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systems)
        {
            Add(systems.Create<SelfDestructTimerSystem>());
            
            Add(systems.Create<CleanupGameDestructedViewSystem>());
            
            Add(systems.Create<CleanupGameDestructedSystem>());
        }
    }
}