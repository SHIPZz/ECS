using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    [CreateAssetMenu(menuName = "Enemy spawn config", fileName = "EnemySpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField] private List<WaveData> _waveDatas;

        public WaveData GetWave(int stage)
        {
            return stage > _waveDatas.Count ? _waveDatas[^1] : _waveDatas[stage - 1];
        }
    }
}