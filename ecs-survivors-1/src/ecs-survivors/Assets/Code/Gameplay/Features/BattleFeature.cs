using Code.Common;
using Code.Gameplay.Cameras;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armament;
using Code.Gameplay.Features.CharacterStats.Systems;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Death;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Follow;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Pull;
using Code.Gameplay.Features.Scale;
using Code.Gameplay.Features.Skin;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features
{
    public sealed class 
        BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<InputFeature>());
            Add(systemses.Create<BindViewFeature>());
            
            Add(systemses.Create<ScaleFeature>());
            Add(systemses.Create<HeroFeature>());
            
            Add(systemses.Create<CameraFeature>());
            Add(systemses.Create<EnemyFeature>());
            
            
            Add(systemses.Create<CooldownFeature>());
            Add(systemses.Create<EnchantFeature>());
            
            Add(systemses.Create<LootingFeature>());
            
            Add(systemses.Create<CollectTargetsFeature>());
            Add(systemses.Create<PullFeature>());
            Add(systemses.Create<LevelUpFeature>());
            Add(systemses.Create<AbilityFeature>());
            
            Add(systemses.Create<StatusFeature>());
            Add(systemses.Create<EffectApplicationFeature>());
            Add(systemses.Create<StatusVisualsFeature>());
            Add(systemses.Create<ArmamentFeature>());
            Add(systemses.Create<EffectFeature>());
            Add(systemses.Create<StatsFeature>());
            Add(systemses.Create<FollowTargetFeature>());
            Add(systemses.Create<SkinFeature>());
            
            Add(systemses.Create<MovementFeature>());
            Add(systemses.Create<ProcessDestructedFeature>());
            
            Add(systemses.Create<DeathFeature>());
            Add(systemses.Create<LifetimeFeature>());
        }
    }
}