using Code.Gameplay.Features.Movement;
using Code.Infrastructure.View.Systems;

namespace Code.Infrastructure.View
{
    public sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPathSystem>());
            Add(systems.Create<BindEntityViewFromViewPrefabSystem>());
        }
    }
}