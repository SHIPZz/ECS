using Code.Infrastructure.Systems;

namespace Code.Gameplay.Cameras
{
    public sealed class CameraFeature : Feature
    {
        public CameraFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<CameraFollowHeroSystem>());
        }
    }
}