namespace Code.Gameplay.Features.Ability.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateRadialBoltAbility(int level);
        GameEntity CreateVegetableAbility(int level);
        GameEntity CreateBounceBoltAbility(int level);
        GameEntity CreateScatteringBoltAbility(int level);
    }
}