using Code.Gameplay.Features.Movement;

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