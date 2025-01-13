using Code.Common;
using Code.Gameplay.Cameras;
using Code.Gameplay.Features.Ability;
using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Chase;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Death;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Scale;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<ScaleFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<CooldownFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<ArmamentFeature>());
            Add(systems.Create<ChaseFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<DamageApplicationFeature>());
            Add(systems.Create<DeathFeature>());
        }
    }
}