using Entitas;

namespace Code.Gameplay.Features.Death
{
    public class DeathFeature : Feature
    {
        public DeathFeature()
        {
            
        }
    }

    public class DeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DeathSystem(GameContext game)
        {
            // _entities = game.GetGroup(GameMatcher
                // .AllOf(GameMatcher.matcher));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                
            }
        }
    }
}