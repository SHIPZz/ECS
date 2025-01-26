using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class AddPullableToPullableHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _pullableHolders;

        public AddPullableToPullableHolderSystem(GameContext game)
        {
            _pullables = game.GetGroup(GameMatcher.Pullable);
            
            _pullableHolders = game.GetGroup(GameMatcher.PullTargetList);
        }

        public void Execute()
        {
            foreach (GameEntity pullableHolder in _pullableHolders)
            foreach (GameEntity pullable in _pullables)
            {
                if (!CanAddPullableToHolder(pullableHolder, pullable))
                    continue;

                pullableHolder.PullTargetList.Add(pullable.Id);
            }
        }

        private bool CanAddPullableToHolder(GameEntity pullableHolder, GameEntity pullable)
        {
            return pullable.Id != pullableHolder.Id 
                   && pullableHolder.PullTargetList.Count < pullableHolder.MaxPullTargetHold 
                   && !pullableHolder.PullTargetList.Contains(pullable.Id); 
        }

    }
}