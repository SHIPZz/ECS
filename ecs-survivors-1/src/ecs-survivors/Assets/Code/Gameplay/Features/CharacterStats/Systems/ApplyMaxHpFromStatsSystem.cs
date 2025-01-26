using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyMaxHpFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyMaxHpFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.MaxHp,
                    GameMatcher.StatModifiers
                ));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceMaxHp(ChangeMaxHp(statOwner).ZeroIfNegative());
            }
        }

        private static float ChangeMaxHp(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.MaxHp] + statOwner.StatModifiers[Stats.MaxHp];
        }
    }
}