using UnityEngine;

namespace Code.Gameplay.Features.Armament
{
    public interface IArmamentFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
    }
}