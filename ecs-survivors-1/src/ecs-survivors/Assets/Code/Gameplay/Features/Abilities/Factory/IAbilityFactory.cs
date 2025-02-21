using Code.Gameplay.Features.Abilities.Config;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityTypeId abilityTypeId, int level);
    }
}