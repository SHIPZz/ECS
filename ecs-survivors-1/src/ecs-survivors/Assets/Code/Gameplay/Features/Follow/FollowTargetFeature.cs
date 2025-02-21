using Code.Gameplay.Features.Follow.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Follow
{
    public sealed class FollowTargetFeature : Feature
    {
        public FollowTargetFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<FollowTargetSystem>());
            Add(systemses.Create<UpdateLastFollowTargetsSystem>());
            Add(systemses.Create<MarkFollowingUpSystem>());
            Add(systemses.Create<MarkFollowingUpWithoutMaxDistanceSystem>());
            Add(systemses.Create<SetNewFollowTargetOnFollowingUpSystem>());
        }
    }
}