using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(128);

        public HeroDeathSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Dead,
                    GameMatcher.DeathProcessing
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.RemoveTargetCollectionComponents();
                entity.isTurnAlongDirection = false;
                
                entity.HeroAnimator.PlayDied();

                if (entity.hasDeathAnimationDuration)
                    entity.ReplaceSelfDestructTimer(entity.DeathAnimationDuration);
            }
        }
    }
}