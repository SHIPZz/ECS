using Entitas;
using UnityEditor.Animations;
using UnityEngine;

namespace Code.Gameplay.Features.Skin
{
    [Game] public class TargetSprite : IComponent { public Sprite Value; }
    
    [Game] public class NewSkinAnimator : IComponent { public RuntimeAnimatorController Value; }
    
    [Game] public class SkinChanged : IComponent {  }
}