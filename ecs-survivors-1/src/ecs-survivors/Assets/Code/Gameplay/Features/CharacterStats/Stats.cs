using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Gameplay.Features.CharacterStats
{
    public enum Stats
    {
        None =0,
        Speed = 1,
        MaxHp = 2,
        Damage = 3,
        Scale = 4,
        Hp = 5,
    }

    public static class InitStats
    {
        public static Dictionary<Stats, float> EmptyStatDictionary()
        {
            return Enum.GetValues(typeof(Stats))
                .Cast<Stats>()
                .Except(new[] { Stats.None })
                .ToDictionary(x => x, _ => 0f);
        }
    }
}