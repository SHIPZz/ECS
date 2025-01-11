using Code.Common;
using Code.Common.Systems;
using Code.Gameplay.Cameras;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;

namespace Code.Gameplay.Features
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<DamageApplicationFeature>());
        }
    }
}