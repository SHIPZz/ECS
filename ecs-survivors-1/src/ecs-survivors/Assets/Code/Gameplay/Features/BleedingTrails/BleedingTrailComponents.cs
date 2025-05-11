using System.Collections.Generic;
using Code.Gameplay.Features.BleedingTrails.Configs;
using Code.Gameplay.Features.BleedingTrails.Enums;
using Code.Gameplay.Features.BleedingTrails.Visuals;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails
{
    [Game] public class BleedingRequested : IComponent {  }
    
    [Game] public class BleedingTrailSpawnAvailable : IComponent {  }
    
    [Game] public class BleedingAvailable : IComponent {  }
    
    [Game] public class Bleeding : IComponent {  }
    
    [Game] public class BleedingTrail : IComponent {  }
    
    [Game] public class BleedTrailOffset : IComponent { public float Value;  }
    
    [Game] public class BleedTrailViewComponent : IComponent { public BleedingTrailView Value;  }
    
    [Game] public class LongBleedTrailOffset : IComponent { public float Value;  }
    
    [Game] public class LongBleedTrailSpeed : IComponent { public float Value;  }
    
    [Game] public class SplashBleedTrailSpeed : IComponent { public float Value;  }
    
    [Game] public class BleedingTrailTypeIdComponent : IComponent { public BleedingTrailTypeId Value;  }
    
    [Game] public class BleedingTrails : IComponent { public Dictionary<BleedingTrailTypeId, List<BleedingTrailData>> Value;  }
    
    [Game] public class LastBleedTrailSpawnTime : IComponent { public float Value; }
    
    [Game] public class BleedSpawnList : IComponent { public List<BleedingTrailData> Value; }

    [Game] public class BleedTrailSpawnInterval : IComponent { public float Value; }
    
    [Game] public class BleedingTrailSpawnScale : IComponent { public Vector3 Value; }
}