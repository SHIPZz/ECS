using Code.Infrastructure.View.Factory;
using Entitas;

namespace Code.Infrastructure.View.Systems
{
    public class BindEntityViewFromViewPrefabSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEntityViewFactory _entityViewFactory;

        public BindEntityViewFromViewPrefabSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPrefab)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                _entityViewFactory.CreateViewForEntityFromPrefab(entity);
            }
        }
    }
}