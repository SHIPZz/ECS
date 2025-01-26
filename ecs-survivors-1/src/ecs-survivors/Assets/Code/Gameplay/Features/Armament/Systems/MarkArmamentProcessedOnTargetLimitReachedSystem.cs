using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class MarkArmamentProcessedOnTargetLimitReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        public MarkArmamentProcessedOnTargetLimitReachedSystem(GameContext game)
        {
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.ProcessedTargetsBuffer, 
                    GameMatcher.TargetLimit)
                .NoneOf(GameMatcher.OverflowProcessedTargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                if (armament.ProcessedTargetsBuffer.Count >= armament.TargetLimit)
                {
                    armament.isProcessed = true;
                }
            }
        }
    }
}