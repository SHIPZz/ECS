using System;
using UnityEngine;

namespace Code.Gameplay.Features.Statuses
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId StatusTypeId;
        public float Value;
        public float Duration;
        public float Period;
        public ReplaceSkinSetup TargetSkinSetup;
        public bool Stackable;
    }

    [Serializable]
    public class ReplaceSkinSetup
    {
        public Sprite TargetSkin;
        public RuntimeAnimatorController AnimatorController;
    }
}