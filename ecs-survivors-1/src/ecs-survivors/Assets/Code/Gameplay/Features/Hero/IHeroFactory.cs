using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 at);
    }
}