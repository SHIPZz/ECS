using Code.Common.Entity;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Services;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow : BaseWindow
    {
        public Transform AbilityLayout;
        private IAbilityUpgradeService _abilityUpgradeService;
        private IAbilityUIFactory _abilityUIFactory;
        private IStaticDataService _staticDataService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IAbilityUIFactory abilityUIFactory,
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticDataService,
            IWindowService windowService)
        {
            _windowService = windowService;
            _staticDataService = staticDataService;
            _abilityUIFactory = abilityUIFactory;
            Id = WindowId.LevelUpWindow;

            _abilityUpgradeService = abilityUpgradeService;
        }

        protected override void Initialize()
        {
            foreach (AbilityUpgradeOption upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
            {
                AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);

                _abilityUIFactory.CreateAbilityCard(AbilityLayout)
                    .Setup(upgradeOption.Id, abilityLevel, OnSelected);
            }
        }

        private void OnSelected(AbilityTypeId abilityType)
        {
            CreateEntity.Empty()
                .AddAbilityTypeId(abilityType)
                .isUpgradeRequest = true;
            
            _windowService.Close(Id);
        }
    }
}