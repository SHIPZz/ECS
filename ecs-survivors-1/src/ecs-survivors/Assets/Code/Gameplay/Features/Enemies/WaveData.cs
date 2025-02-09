using System;
using System.Collections.Generic;

namespace Code.Gameplay.Features.Enemies
{
    [Serializable]
    public class WaveData
    {
        public float Cooldown;
        public float SpawnInterval;
        public int Count;

        public List<EnemyTypeId> Enemies;
        public float EnemyAppearTime;
        public List<EnemyTypeId> EnemiesToAppear;
    }
}