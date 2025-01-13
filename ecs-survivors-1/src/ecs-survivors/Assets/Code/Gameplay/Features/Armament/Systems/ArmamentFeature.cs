using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Armament.Systems
{
    public sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkArmamentProcessedOnTargetLimitReachedSystem>());
            Add(systems.Create<MarkArmamentProcessedOnBounceCountReachedSystem>());
            Add(systems.Create<ReplaceArmamentChaseTargetOnCollectSystem>());
            Add(systems.Create<ScatterOnCollectSystem>());
            Add(systems.Create<FinalizeProcessedArmamentSystem>());
        }
    }
}