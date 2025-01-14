using UnityEngine;

namespace Code.Gameplay.Features.Armament.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
        GameEntity CreateRadialBolt(int level, Vector3 at);
        GameEntity CreateBouncingBolt(int level, Vector3 at);
        GameEntity CreateScatteringBolt(int level, Vector3 at);
    }
}