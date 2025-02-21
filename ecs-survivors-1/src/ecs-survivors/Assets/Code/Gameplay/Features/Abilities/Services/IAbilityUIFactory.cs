using Code.Gameplay.Features.LevelUp.Behaviour;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Services
{
    public interface IAbilityUIFactory
    {
        AbilityCard CreateAbilityCard(Transform parent);
    }
}