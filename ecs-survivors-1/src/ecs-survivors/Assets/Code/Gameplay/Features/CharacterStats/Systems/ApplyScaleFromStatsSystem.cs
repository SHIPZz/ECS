using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplyScaleFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyScaleFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.Scale,
                    GameMatcher.StatModifiers
                ));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceScale(IncreaseScale(statOwner));
            }
        }

        private static Vector3 IncreaseScale(GameEntity statOwner)
        {
            var statOwnerBaseStat = statOwner.BaseStats[Stats.Scale];
            var statOwnerStatModifier = statOwner.StatModifiers[Stats.Scale];
            
            var targetScale = statOwnerBaseStat + statOwnerStatModifier;
            
            return new Vector3(targetScale, targetScale, targetScale);
        }
    }
}