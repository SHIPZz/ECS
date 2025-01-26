using Code.Gameplay.Features.Follow.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Follow
{
    public sealed class FollowTargetFeature : Feature
    {
        public FollowTargetFeature(ISystemFactory systems)
        {
            Add(systems.Create<FollowTargetSystem>());
            Add(systems.Create<UpdateLastFollowTargetsSystem>());
            Add(systems.Create<MarkFollowingUpSystem>());
            Add(systems.Create<MarkFollowingUpWithoutMaxDistanceSystem>());
            Add(systems.Create<SetNewFollowTargetOnFollowingUpSystem>());
        }
    }
}