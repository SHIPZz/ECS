using System.Collections.Generic;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails
{
    [Game] public class BleedingTrailSpawnCooldown : IComponent { public float Value; }
    
    [Game] public class BleedingTrailSpawnCooldownUp : IComponent {  }
    
    [Game] public class BleedingTrailSpawnSprite : IComponent { public Sprite Value;  }
    
    [Game] public class BleedTrailOffset : IComponent { public float Value;  }
    
    [Game] public class LongBleedTrailOffset : IComponent { public float Value;  }
    
    [Game] public class InitialBleedingTrails : IComponent { public List<BleedingTrailData> Value;  }
    
    [Game] public class MovingBleedingTrails : IComponent { public List<BleedingTrailData> Value;  }
    
    [Game] public class FinalBleedingTrails : IComponent { public List<BleedingTrailData> Value;  }
    
    [Game] public class BleedingTrailTypeIdComponent : IComponent { public BleedingTrailTypeId Value;  }
    
    [Game] public class BleedingTrailViewComponent : IComponent { public BleedingTrailView Value;  }
    
    [Game] public class BleedingTrailSpawnCooldownLeft : IComponent { public float Value; }
    
    [Game] public class BleedingTrailSpawnPosition : IComponent { public Vector3 Value; }
    
    [Game] public class BleedingTrailSpawnRotation : IComponent { public Quaternion Value; }
    
    [Game] public class LastTrailSpawnTime : IComponent { public float Value; }

    [Game] public class TrailSpawnInterval : IComponent { public float Value; }
    
    [Game] public class BleedingTrailSpawnScale : IComponent { public Vector3 Value; }
}