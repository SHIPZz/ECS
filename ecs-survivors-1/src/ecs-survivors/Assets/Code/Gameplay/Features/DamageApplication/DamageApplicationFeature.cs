﻿using Code.Gameplay.Features.DamageApplication.Systems;
using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Features.DamageApplication
{
    public sealed class DamageApplicationFeature : Feature
    {
        public DamageApplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyDamageOnTargetsSystem>());
        }
    }
}