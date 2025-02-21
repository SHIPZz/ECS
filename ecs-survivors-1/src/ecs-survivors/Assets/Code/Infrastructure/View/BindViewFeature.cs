using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Systems;

namespace Code.Infrastructure.View
{
    public sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<BindEntityViewFromPathSystem>());
            Add(systemses.Create<BindEntityViewFromViewPrefabSystem>());
        }
    }
}