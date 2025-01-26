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
            _pullableHolders = game.GetGroup(GameMatcher.PullTargetList);
        }

        public void Execute()
        {
            if (_pullableHolders.count <= 0)
                return;

            foreach (GameEntity pullTargetsHolder in _pullableHolders)
            foreach (int targetId in pullTargetsHolder.PullTargetList)
            {
                if (pullTargetsHolder.PullTargetList.Count < pullTargetsHolder.MaxPullTargetHold) 
                    continue;
                
                GameEntity target = _game.GetEntityWithId(targetId);

                if (target == null || target.isPulling)
                    continue;

                target.isPulling = true;

                target.AddFollowTargetId(pullTargetsHolder.Id);
                target.BaseStats[Stats.Speed] = 20;
            }
        }
    }
}