using Code.Gameplay.Features.Death.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Death
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
        }
    }
}