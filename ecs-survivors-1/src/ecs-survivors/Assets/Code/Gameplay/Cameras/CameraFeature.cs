using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

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