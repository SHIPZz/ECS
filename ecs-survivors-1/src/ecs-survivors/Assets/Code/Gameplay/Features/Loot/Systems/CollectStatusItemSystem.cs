﻿using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectStatusItemSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IStatusApplier _statusApplier;

        public CollectStatusItemSystem(GameContext game, IStatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _collected = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.StatusSetups
                ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Id,
                GameMatcher.WorldPosition
            ));
        }

        public void Execute()
        {
            foreach (GameEntity collected in _collected)
            foreach (GameEntity hero in _heroes)
            foreach (StatusSetup statusSetup in collected.StatusSetups)
            {
                _statusApplier.ApplyStatus(statusSetup, producerId: hero.Id, targetId: hero.Id);
            }
        }
    }
}