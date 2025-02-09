using Code.Gameplay.Features.Abilities.Services;
using Code.Gameplay.Features.LevelUp.Behaviour;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityUIFactory : IAbilityUIFactory
    {
        private const string AbilityCardPrefabPath = "UI/Abilities/AbilityCard";

        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public AbilityUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public AbilityCard CreateAbilityCard(Transform parent)
        {
            var prefab = _assetProvider.LoadAsset<AbilityCard>(AbilityCardPrefabPath);

            return _instantiator.InstantiatePrefabForComponent<AbilityCard>(prefab, parent);
        }
    }
}