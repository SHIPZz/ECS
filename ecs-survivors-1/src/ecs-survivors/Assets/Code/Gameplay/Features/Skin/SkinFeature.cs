using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Skin
{
    public sealed class SkinFeature : Feature
    {
        public SkinFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<ChangeAnimatorOnTargetSkinSystem>());
            Add(systemses.Create<ChangeSkinSystem>());
        }
    }
}