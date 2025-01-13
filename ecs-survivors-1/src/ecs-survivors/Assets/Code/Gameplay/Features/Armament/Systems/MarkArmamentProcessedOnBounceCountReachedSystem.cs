using Entitas;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class MarkArmamentProcessedOnBounceCountReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        public MarkArmamentProcessedOnBounceCountReachedSystem(GameContext game)
        {
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.BouncingCount,
                    GameMatcher.MaxBouncingCount,
                    GameMatcher.ProcessedTargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                if (armament.BouncingCount >= armament.MaxBouncingCount)
                {
                    armament.isProcessed = true;
                }
            }
        }
    }
}