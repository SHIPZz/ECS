using Code.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class MoveToPullableHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullableHolders;
        private readonly GameContext _game;

        public MoveToPullableHolderSystem(GameContext game)
        {
            _game = game;
            _pullableHolders = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.PullTargetList,
                GameMatcher.MinCountToPullTargets));
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

                target.AddFollowTargetId(pullTargetsHolder.Id);
                
                if (target.hasBaseStats)
                    target.BaseStats[Stats.Speed] = 20; //todo refactor
            }
        }
    }
}