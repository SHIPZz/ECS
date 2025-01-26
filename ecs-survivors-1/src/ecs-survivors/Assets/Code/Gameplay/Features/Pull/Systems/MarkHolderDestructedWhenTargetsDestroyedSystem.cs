using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class MarkHolderDestructedWhenTargetsDestroyedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _game;

        public MarkHolderDestructedWhenTargetsDestroyedSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.PullTargetList,
                    GameMatcher.MaxPullTargetHold,
                    GameMatcher.DestructOnMaxPullTargetReached,
                    GameMatcher.PullTargetHolder
                ));
        }

        public void Execute()
        {
            foreach (GameEntity holder in _entities)
            {
                bool allDestroyed = true;

                if (holder.PullTargetList.Count <= 0)
                    continue;

                if (holder.PullTargetList.Count >= holder.MaxPullTargetHold)
                {
                    foreach (int pullTargetId in holder.PullTargetList)
                    {
                        GameEntity pullable = _game.GetEntityWithId(pullTargetId);

                        if (pullable != null)
                            allDestroyed = pullable.isDestructed;
                    }

                    holder.isDestructed = allDestroyed;
                }
            }
        }
    }
}