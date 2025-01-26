using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Scale
{
    [Game]
    public class Scale : IComponent { public Vector3 Value; }

    [Game] public class ScaleTransform : IComponent { public Transform Value; }
}