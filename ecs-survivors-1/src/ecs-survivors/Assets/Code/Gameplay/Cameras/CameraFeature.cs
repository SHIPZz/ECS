using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Cameras
{
    public sealed class CameraFeature : Feature
    {
        public CameraFeature(ISystemFactory systems)
        {
            Add(systems.Create<CameraFollowHeroSystem>());
        }
    }
}