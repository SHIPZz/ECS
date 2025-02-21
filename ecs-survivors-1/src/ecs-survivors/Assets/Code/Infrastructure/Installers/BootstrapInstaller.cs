using Code.Common.EntityIndicies;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Position;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Enchants.UIFactories;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.LevelUp.Services;
using Code.Gameplay.Features.Loot.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
using Code.Meta.Factory;
using Code.Meta.Features.Achievements.Services;
using Code.Meta.Features.Simulation.Roll;
using Code.Meta.SaveLoad;
using Code.Meta.UI.GoldHolders.Service;
using Code.Meta.UI.Shop;
using Code.Meta.UI.Shop.Factory;
using Code.Progress.Provider;
using Code.States.Factory;
using Code.States.GameStates;
using Code.States.StateMachine;
using Entitas;
using RSG;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public EnemySpawnConfig EnemySpawnConfig;
        public RollConfig RollConfig;
        public AchievementsConfig AchievementsConfig;
        
        public override void InstallBindings()
        {
            BindInputService();
            BindSystemFactory();
            BindInfrastructureServices();
            BindAssetManagementServices();
            BindCommonServices();
            BindContexts();
            BindGameplayServices();
            BindCameraProvider();
            BindGameplayFactories();
            BindUiFactories();
            BindEffectFactory();
            BindEntityIndices();
            BindUIServices();
            BindGameStates();
            BindMetaServices();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
            
            Container.BindInstance(EnemySpawnConfig);
            Container.BindInstance(AchievementsConfig);
            Container.BindInstance(RollConfig);
        }

        private void BindMetaServices()
        {
            Container.Bind<IMetaFactory>().To<MetaFactory>().AsSingle();
            Container.Bind<IAchievementService>().To<AchievementService>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IStorageUIService>().To<StorageUIService>().AsSingle();
            Container.Bind<IShopUIService>().To<ShopUIService>().AsSingle();
        }
        
        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActualizeProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
            Container.BindInterfacesAndSelfTo<AfterGameOverState>().AsSingle();
        }

        private void BindUiFactories()
        {
            Container.BindInterfacesAndSelfTo<WindowFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnchantUIFactory>().AsSingle();
            Container.Bind<IShopUIFactory>().To<ShopUIFactory>().AsSingle();
            Container.Bind<IShopItemFactory>().To<ShopItemFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityUIFactory>().AsSingle();
        }

        private void BindEntityIndices()
        {
            Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
        }

        private void BindEffectFactory()
        {
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
        }

        private void BindSystemFactory()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
            
            Container.Bind<IContext<GameEntity>>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<IContext<MetaEntity>>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }

        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IAbilityUpgradeService>().To<AbilityUpgradeService>().AsSingle();
            Container.Bind<ILevelUpService>().To<LevelUpService>().AsSingle();
            Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IGetClosestEntityService>().To<GetClosestEntityService>().AsTransient();
            Container.Bind<IStatusApplier>().To<StatusApplier>().AsSingle();
        }

        private void BindGameplayFactories()
        {
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
            Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IProgressProvider>().To<ProgressProvider>().AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindAssetManagementServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<IGetRandomPositionService>().To<GetRandomPositionService>().AsSingle();
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        public void Initialize()
        {
            Promise.UnhandledException += LogPromiseException;
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void LogPromiseException(object sender, ExceptionEventArgs e)
        {
            Debug.LogError(e.Exception);
        }
    }
}