using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Factory;

namespace Code.Gameplay.Features.Abilities.Upgrade
{
    public class AbilityUpgradeService : IAbilityUpgradeService
    {
        private const int MinRepeatedAbilitiesToOffer = 1;
        private const int MaxCardsToOffer = 2;

        private readonly Dictionary<AbilityTypeId, int> _currentAbilities;
        private readonly IRandomService _random;
        private readonly IAbilityFactory _abilityFactory;

        public AbilityUpgradeService(IRandomService randomService, IAbilityFactory abilityFactory)
        {
            _currentAbilities = new Dictionary<AbilityTypeId, int>();
            _random = randomService;
            _abilityFactory = abilityFactory;
        }

        public int GetAbilityLevel(AbilityTypeId abilityId) =>
            _currentAbilities.TryGetValue(abilityId, out int level)
                ? level
                : 0;

        public void InitializeAbility(AbilityTypeId ability)
        {
            if (!_currentAbilities.TryAdd(ability, 1))
                throw new Exception($"Ability {ability} is already initialized");

            _abilityFactory.CreateAbility(ability, 1);
        }
        
        public void UpgradeAbility(AbilityTypeId ability)
        {
            if (_currentAbilities.ContainsKey(ability))
                _currentAbilities[ability]++;
            else
                InitializeAbility(ability);
        }

        public List<AbilityUpgradeOption> GetUpgradeOptions()
        {
            int repeatedAbilitiesToReturnCount = MinRepeatedAbilitiesToOffer +
                                                 _random.Range(0, Math.Min(_currentAbilities.Count, MaxCardsToOffer));
            int newAbilitiesToReturnCount = Math.Min(MaxCardsToOffer - repeatedAbilitiesToReturnCount,
                UnacquiredAbilities().Count);

            List<AbilityUpgradeOption> upgradeOptions = GetRandomRepeatedAbilities(repeatedAbilitiesToReturnCount);
            upgradeOptions.AddRange(GetRandomUntappedAbilities(newAbilitiesToReturnCount));

            return upgradeOptions;
        }

        private List<AbilityUpgradeOption> GetRandomRepeatedAbilities(int count) =>
            _currentAbilities.Keys
                .OrderBy(_ => _random.Range(0, _currentAbilities.Count))
                .Take(count)
                .Select(abilityId => new AbilityUpgradeOption
                    { Id = abilityId, Level = _currentAbilities[abilityId] + 1 })
                .ToList();

        private List<AbilityUpgradeOption> GetRandomUntappedAbilities(int count) =>
            UnacquiredAbilities()
                .OrderBy(_ => _random.Range(0, UnacquiredAbilities().Count))
                .Take(count)
                .Select(abilityId => new AbilityUpgradeOption { Id = abilityId, Level = 1 })
                .ToList();

        private List<AbilityTypeId> UnacquiredAbilities() =>
            Enum
                .GetValues(typeof(AbilityTypeId))
                .Cast<AbilityTypeId>()
                .Except(_currentAbilities.Keys)
                .Except(new[] { AbilityTypeId.None })
                .ToList();

        public void Cleanup()
        {
            _currentAbilities.Clear();
        }
    }
}