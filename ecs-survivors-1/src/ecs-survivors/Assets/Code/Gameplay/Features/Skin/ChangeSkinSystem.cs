using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Skin
{
    public class ChangeSkinSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ChangeSkinSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SpriteRenderer,
                    GameMatcher.TargetSprite
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.SpriteRenderer.sprite != entity.TargetSprite)
                    entity.SpriteRenderer.sprite = entity.TargetSprite;
            }
        }
    }
}