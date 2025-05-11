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
using Code.Gameplay.Features.GameOver;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.KickingBacks;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Lifetime;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.BleedingTrails;
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
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<ScaleFeature>());
            Add(systems.Create<HeroFeature>());
            
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<EnemyFeature>());
            
            
            
            Add(systems.Create<CooldownFeature>());
            Add(systems.Create<EnchantFeature>());
            
            Add(systems.Create<LootingFeature>());
            
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<KickingBackFeature>());
            Add(systems.Create<ArmamentFeature>());
            Add(systems.Create<BleedingTrailFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<PullFeature>());
            Add(systems.Create<LevelUpFeature>());
            Add(systems.Create<AbilityFeature>());
            
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<EffectApplicationFeature>());
            Add(systems.Create<StatusVisualsFeature>());
            Add(systems.Create<EffectFeature>());
            Add(systems.Create<StatsFeature>());
            Add(systems.Create<FollowTargetFeature>());
            Add(systems.Create<SkinFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
            
            Add(systems.Create<DeathFeature>());
            Add(systems.Create<GameOverOnHeroDeathSystem>());
            Add(systems.Create<LifetimeFeature>());
        }
    }
}