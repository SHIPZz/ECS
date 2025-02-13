using Code.Common;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Simulation;
using Code.Meta.Features.Simulation.Roll;
using Code.Meta.Features.Simulation.Systems;
using Code.Meta.UI.GoldHolders.Behaviours;
using Code.Progress;

namespace Code.Meta.UI
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<EmitTickSystem>(1f));
            Add(systemFactory.Create<CalculateRollTimeSystem>());
            Add(systemFactory.Create<EmitRollSystem>());
            Add(systemFactory.Create<PeriodicallySaveProgressSystem>(10f));
            
            Add(systemFactory.Create<SimulationFeature>());
            Add(systemFactory.Create<RefreshGoldSystem>());
            
            Add(systemFactory.Create<CleanupTickSystem>());
            
            Add(systemFactory.Create<CleanUpRollSystem>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}

