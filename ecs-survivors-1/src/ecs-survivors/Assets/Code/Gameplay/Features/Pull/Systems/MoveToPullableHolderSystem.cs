using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class MoveToPullableHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullableHolders;
        private readonly GameContext _game;
        private IStatusApplier _statusApplier;

        public MoveToPullableHolderSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _game = game;
            _pullableHolders = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.PullTargetList,
                GameMatcher.PullTargetHolder,
                GameMatcher.MinCountToPullTargets
                ));
        }

        public void Execute()
        {
            if (_pullableHolders.count <= 0)
                return;

            foreach (GameEntity pullTargetsHolder in _pullableHolders)
            foreach (int targetId in pullTargetsHolder.PullTargetList)
            {
                if (pullTargetsHolder.PullTargetList.Count < pullTargetsHolder.MinCountToPullTargets)
                    continue;

                GameEntity target = _game.GetEntityWithId(targetId);

                if (target == null || target.isPulling)
                    continue;

                if (pullTargetsHolder.Id != target.PullProducerId)
                    continue;

                target.isPulling = true;
                target.isMoving = true;
                target.isMovingAvailable = true;

                target.AddFollowTargetId(pullTargetsHolder.Id);
            }
        }
    }
}