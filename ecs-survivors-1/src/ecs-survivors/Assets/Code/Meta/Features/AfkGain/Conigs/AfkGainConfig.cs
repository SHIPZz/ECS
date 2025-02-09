using UnityEngine;

namespace Code.Meta.Features.AfkGain.Conigs
{
    [CreateAssetMenu(fileName = "AfkGainConfig", menuName = "Gameplay/AfkGainConfig")]
    public class AfkGainConfig : ScriptableObject
    {
        public float GoldPerSecond = 1;
        public float EnergyChance = 0.3f;
        public float EnergyPerRoll = 1f;
    }
}