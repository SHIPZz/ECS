using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemies
{
    [Game] public class Enemy : IComponent { }
    
    [Game] public class Healer : IComponent { }
    
    [Game] public class HealMask : IComponent { public int Value; }
    
    [Game] public class Buffer : IComponent { }

    [Game] public class ChaseHero : IComponent { }
    
    [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
    
    [Game] public class SpawnTimer : IComponent { public float Value; }
    
    [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
    
    [Game] public class NeedFindClosestEnemy : IComponent {  }
}