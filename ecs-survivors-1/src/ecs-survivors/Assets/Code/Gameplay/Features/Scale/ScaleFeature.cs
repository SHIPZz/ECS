using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Scale.Systems;

namespace Code.Gameplay.Features.Scale
{
    public sealed class ScaleFeature : Feature
    {
        public ScaleFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateScaleSystem>());
        }
    }
}