using Code.Gameplay.Features.Scale.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Scale
{
    public sealed class ScaleFeature : Feature
    {
        public ScaleFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<UpdateScaleSystem>());
        }
    }
}