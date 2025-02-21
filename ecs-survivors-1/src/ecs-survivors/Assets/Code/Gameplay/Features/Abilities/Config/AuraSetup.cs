using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Config
{
    [Serializable]
    public class AuraSetup
    {
        public AuraTypeId AuraTypeId;
        
        public float Radius = 1;
        public float Interval = 1;
        public float Cooldown = 2;
        public float Lifetime = 2f;
        
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public LayerMask LayerMask;
        
        public EntityBehaviour Prefab;
    }

    public enum AuraTypeId
    {
        None =0,
        SpeedUp = 1,
        Heal = 2,
        Damage = 3,
    }
}