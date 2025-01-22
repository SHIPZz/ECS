using Code.Gameplay.Features.Ability.Config;

namespace Code.Gameplay.Features.Ability.Factory
{
    public interface IAbilityFactory
    {
        void CreateAbility(AbilityTypeId abilityTypeId, int level);
    }
}