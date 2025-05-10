using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.BleedingTrails.Systems
{
    public class PutOnBleedingTrailSpawnCooldownOnHitSystem : ReactiveSystem<GameEntity>
    {
        public PutOnBleedingTrailSpawnCooldownOnHitSystem(IContext<GameEntity> game) : base(game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GotHit.Added());

        protected override bool Filter(GameEntity entity) => 
            entity.hasBleedingTrailSpawnCooldown 
            && entity.isBleedingTrailSpawnCooldownUp
            && entity.isGotHit
        ;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.ReplaceBleedingTrailSpawnCooldownLeft(entity.BleedingTrailSpawnCooldown);
                entity.isBleedingTrailSpawnCooldownUp = false;
            }
        }
    }
}