using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class FinalizeProcessedArmamentSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        public FinalizeProcessedArmamentSystem(GameContext game)
        {
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.ProcessedTargetsBuffer,
                    GameMatcher.TargetLimit,
                    GameMatcher.Processed
                ));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                if (armament.ProcessedTargetsBuffer.Count >= armament.TargetLimit)
                {
                    armament.RemoveTargetCollectionComponents();
                    armament.isDestructed = true;
                }
            }
        }
    }
}