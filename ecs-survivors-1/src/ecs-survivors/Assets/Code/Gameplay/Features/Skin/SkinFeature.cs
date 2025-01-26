using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Skin
{
    public sealed class SkinFeature : Feature
    {
        public SkinFeature(ISystemFactory systems)
        {
            Add(systems.Create<ChangeAnimatorOnTargetSkinSystem>());
            Add(systems.Create<ChangeSkinSystem>());
        }
    }
}