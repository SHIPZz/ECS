using Code.Common.Extensions;
using Code.Gameplay.Features.Ability;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Ability.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityFactory _abilityFactory;
        private IStatusApplier _statusApplier;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider,
            IAbilityFactory abilityFactory, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _abilityFactory = abilityFactory;
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _abilityFactory.CreateAbility(AbilityTypeId.Magnificent, 1);

            // _statusApplier.ApplyStatus(new StatusSetup()
            // {
            //     StatusTypeId = StatusTypeId.Vampirism,
            //     Duration = 10,
            // }, hero.Id, hero.Id);

            // _abilityFactory.CreateAbility(AbilityTypeId.OrbitalMushroom, 1);

            // _statusApplier.ApplyStatus(new StatusSetup()
            // {
            //     StatusTypeId = StatusTypeId.PoisonEnchant,
            //     Duration = 25,
            // }, hero.Id, hero.Id);
            //

            // _statusApplier.ApplyStatus(new StatusSetup()
            // {
            //     StatusTypeId = StatusTypeId.ExplosiveEnchant,
            //     Duration = 10,
            // }, hero.Id, hero.Id);

            // _statusApplier.ApplyStatus(new StatusSetup()
            // {
            //     StatusTypeId = StatusTypeId.Hex,
            //     Duration = 10,
            // }, hero.Id, hero.Id);


            // _abilityFactory.CreateAbility(AbilityTypeId.GarlicAura, 1);
            // _abilityFactory.CreateAbility(AbilityTypeId.SpeedUp, 1);
            // _abilityFactory.CreateAbility(AbilityTypeId.IncreaseMaxHp, 1);
            // _abilityFactory.CreateRadialBoltAbility( 1);
            // _abilityFactory.CreateBounceBoltAbility(1);
            // _abilityFactory.CreatePoisonBoltAbility(1);
            // _abilityFactory.CreateScatteringBoltAbility( 1);
            // _abilityFactory.CreateVampirismBoltAbility(1);
        }
    }
}