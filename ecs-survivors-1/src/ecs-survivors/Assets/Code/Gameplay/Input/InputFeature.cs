using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Input.Systems;

namespace Code.Gameplay.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            Add(systems.Create<EmitInputSystem>());
        }
    }
}