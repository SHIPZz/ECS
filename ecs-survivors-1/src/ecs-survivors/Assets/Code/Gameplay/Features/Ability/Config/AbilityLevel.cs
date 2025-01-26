﻿using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Ability.Config
{
    [Serializable]
    public class AbilityLevel
    {
        public float Cooldown = 1f;

        public EntityBehaviour Prefab;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public ProjectileSetup ProjectileSetup;

        public AuraSetup AuraSetup;
    }
}