using Code.Common.Extensions;

namespace Code.Gameplay.Features.Armament.Systems.Poison
{
    public static class PoisonEntityExtensions
    {
        public static GameEntity PutOnPoison(this GameEntity entity, float poisonTime, float damage)
        {
            return entity
                    .With(x => x.AddPoisonTime(poisonTime), when: !entity.hasPoisonTime)
                    .With(x => x.AddPoisonTimeLeft(poisonTime), when: !entity.hasPoisonTimeLeft)
                    .With(x => x.ReplacePoisonTimeLeft(poisonTime), when: entity.hasPoisonTimeLeft)
                    .With(x => x.AddPoisonDamage(damage), when: !entity.hasPoisonDamage)
                ;
        }
    }
}