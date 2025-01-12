using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Death
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
                
                entity.HeroAnimator.PlayDied();

                if (entity.hasDeathAnimationTime)
                    entity.ReplaceSelfDestructTimer(entity.DeathAnimationTime);
            }
        }
    }
}