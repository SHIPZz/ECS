using Code.Common.Configs;
using Code.Gameplay.Features.Ability;
using Code.Gameplay.Features.Ability.Config;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    CollisionLayerConfig CollisionLayerConfig { get; }
    AbilityConfig GetAbilityConfig(AbilityTypeId abilityTypeId);
    AbilityLevel GetAbilityLevel(AbilityTypeId abilityTypeId, int level);
  }
}