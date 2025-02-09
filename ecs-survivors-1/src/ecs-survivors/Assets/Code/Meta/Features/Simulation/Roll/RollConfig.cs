using UnityEngine;

namespace Code.Meta.Features.Simulation.Roll
{
    [CreateAssetMenu(fileName = "RollConfig", menuName = "Gameplay/RollConfig")]
    public class RollConfig : ScriptableObject
    {
        public float RollTime = 1f;
        public float InclusiveMin = 1f;
        public float InclusiveMax = 1f;
    }
}