using Code.Gameplay.Features.LevelUp.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.LevelUp
{
    public sealed class LevelUpFeature : Feature
    {
        public LevelUpFeature(ISystemFactory system)
        {
            Add(system.Create<OpenLevelUpWindowSystem>());
            Add(system.Create<StopTimeOnLevelUpSystem>());
          
            Add(system.Create<UpgradeAbilityOnRequestSystem>());
            
            Add(system.Create<StartTimeOnLevelUpSystem>());
            
            Add(system.Create<FinalizeProcessedLevelUpsSystem>());
            
        }
    }
}