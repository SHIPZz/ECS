using UnityEngine;

namespace Code.Common.Configs
{
    [CreateAssetMenu(fileName = "CollisionLayerConfig", menuName = "Gameplay/Configs/CollisionLayerConfig", order = 1)]
    public class CollisionLayerConfig : ScriptableObject
    {
        public LayerMask PlayerMask;
        public LayerMask EnemyMask;
        public LayerMask PlayerProjectileMask;
    }
}
