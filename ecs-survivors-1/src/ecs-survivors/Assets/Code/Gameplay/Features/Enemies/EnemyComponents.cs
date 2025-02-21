using System.Collections.Generic;
using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemies
{
    [Game] public class Enemy : IComponent { }
    
    [Game] public class EnemySpawnCount : IComponent { public int Value; }
    
    [Game] public class EnemySpawnInterval : IComponent { public float Value; }
    
    [Game] public class EnemySpawnMaxInterval : IComponent { public float Value; }
    
    [Game] public class EnemySpawnAvailable : IComponent {  }
    
    [Game] public class AddingNewEnemyAvailable : IComponent {  }
    
    [Game] public class EnemyAppearTime : IComponent { public float Value; }
    
    [Game] public class EnemyAppearTimeLeft : IComponent { public float Value; }
    
    [Game] public class EnemyAppearTimeUp : IComponent {  }
    
    [Game] public class EnemySpawnIds : IComponent { public List<EnemyTypeId> Value; }
    
    [Game] public class EnemyWave : IComponent { public int Value; }
    
    [Game] public class EnemyDeadCount : IComponent { public int Value; }
    
    [Game] public class Healer : IComponent { }
    
    [Game] public class HealMask : IComponent { public int Value; }
    
    [Game] public class Buffer : IComponent { }

    [Game] public class ChaseHero : IComponent { }
    
    [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
    
    [Game] public class SpawnTimer : IComponent { public float Value; }
    
    [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
    
    [Game] public class NeedFindClosestEnemy : IComponent {  }
}