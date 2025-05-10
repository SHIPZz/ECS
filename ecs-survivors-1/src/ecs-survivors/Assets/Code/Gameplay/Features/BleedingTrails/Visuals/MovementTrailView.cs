using Code.Gameplay.Features.BleedingTrails.Enums;
using UnityEngine;

namespace Code.Gameplay.Features.BleedingTrails.Visuals
{
    public class BleedingTrailView : MonoBehaviour
    {
       [field: SerializeField]  public BleedingTrailTypeId Id { get; private set; }

       [SerializeField] private Sprite _sprite;
       
       public void SetSprite(Sprite sprite) => _sprite = sprite;
    }
}