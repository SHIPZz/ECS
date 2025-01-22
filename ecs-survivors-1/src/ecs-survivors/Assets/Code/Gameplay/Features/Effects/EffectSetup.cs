using System;
using Code.Common.Extensions;

namespace Code.Gameplay.Features.Effects
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId EffectTypeId;
        public float Value;

        public static EffectSetup Create(EffectTypeId effectTypeId, float value)
        {
            EffectSetup effectSetup = new();
            
            return effectSetup
                .With(x =>x.EffectTypeId = effectTypeId)
                .With(x =>x.Value = value)
                ;
        }
    }
}