﻿using Code.Progress;
using Entitas;

namespace Code.Meta.Features.Storage
{
    [Meta] public class Storage : ISavedComponent { }
    
    [Meta] public class Gold : ISavedComponent { public float Value; }
    
    [Meta] public class Energy : ISavedComponent { public float Value; }
    
    [Meta] public class EnergyPerRoll : ISavedComponent { public float Value; }
    
    [Meta] public class GoldPerSecond : ISavedComponent { public float Value; }
    
}