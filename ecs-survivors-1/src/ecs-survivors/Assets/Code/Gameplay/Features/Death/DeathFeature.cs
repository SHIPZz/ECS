using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;

namespace Code.Gameplay.Features.Death
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
            Add(systemFactory.Create<HeroDeathSystem>());
            Add(systemFactory.Create<EnemyDeathSystem>());
            Add(systemFactory.Create<FinishHeroDeathProcessingSystem>());
            Add(systemFactory.Create<FinishEnemyDeathProcessingSystem>());
        }
    }
}