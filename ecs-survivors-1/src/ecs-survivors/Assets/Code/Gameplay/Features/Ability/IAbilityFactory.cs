namespace Code.Gameplay.Features.Ability
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityTypeId abilityTypeId, int level);
    }
}