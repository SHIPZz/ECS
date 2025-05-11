using Code.Gameplay.Features.BleedingTrails.Enums;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Visuals
{
    public class BleedingTrailView : MonoBehaviour
    {
        [field: SerializeField]  public BleedingTrailTypeId Id { get; private set; }

       public void MoveTowardsByTween(Vector3 position, float duration = 0.2f, Ease ease = Ease.OutCubic)
       {
            transform
                .DOMove(position, duration)
                .SetEase(ease);
       }
    }
}