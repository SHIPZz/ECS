using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<InitializeInputSystem>());
            Add(systemses.Create<EmitInputSystem>());
        }
    }
}