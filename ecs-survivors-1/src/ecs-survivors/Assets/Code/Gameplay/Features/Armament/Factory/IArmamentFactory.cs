using Code.Gameplay.Features.Ability.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Armament.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
        GameEntity CreateRadialBolt(int level, Vector3 at);
        GameEntity CreateBouncingBolt(int level, Vector3 at);
        GameEntity CreateScatteringBolt(int level, Vector3 at);
        GameEntity CreateOrbitalMushroom(int level, Vector3 at, float phase);
        GameEntity CreateEffectAura(AbilityTypeId parentAbilityId, int producerId, int level);
        GameEntity CreateExplosion(int producerId, Vector3 at);
        GameEntity CreateAura(AbilityTypeId parentAbilityId, AuraSetup auraSetup, int producerId);
        GameEntity CreateMagnificentBolt(int level, Vector3 at);
        GameEntity CreatePullBolt(int level, Vector3 at);
    }
}