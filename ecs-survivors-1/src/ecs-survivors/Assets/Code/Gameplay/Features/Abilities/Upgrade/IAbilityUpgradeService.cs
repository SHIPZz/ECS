using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Config;

namespace Code.Gameplay.Features.Abilities.Upgrade
{
  public interface IAbilityUpgradeService
  {
    void UpgradeAbility(AbilityTypeId ability);
    void InitializeAbility(AbilityTypeId ability);
    List<AbilityUpgradeOption> GetUpgradeOptions();
    int GetAbilityLevel(AbilityTypeId abilityId);
    void Cleanup();
  }
}