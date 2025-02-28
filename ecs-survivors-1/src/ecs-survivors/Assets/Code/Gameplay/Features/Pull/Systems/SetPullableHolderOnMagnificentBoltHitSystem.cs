﻿using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class SetPullableHolderOnMagnificentBoltHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _magnificentBolt;
        private readonly GameContext _game;
        private readonly IStaticDataService _staticDataService;

        public SetPullableHolderOnMagnificentBoltHitSystem(GameContext game, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _game = game;
            _magnificentBolt = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.MagnificentBoltArmament,
                    GameMatcher.LastCollectedId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _magnificentBolt)
            {
               GameEntity target = _game.GetEntityWithId(armament.LastCollectedId);
               
               if(target.isPullTargetHolder)
                   continue;

               AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Magnificent,1);
               ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;
               
               target.isPullTargetHolder = true;
               target.isPullTargetConsistently = true;
               target.PutOnCooldown(0.2f); //todo refactor
               
               target.isDestructOnMaxPullTargetReached = projectileSetup.DestructOnMaxPullTargetReached;
               target.AddPullTargetList(new List<int>(32));
               target.AddMaxPullTargetHold(projectileSetup.MaxCountToPullTargets); 
               target.AddMinCountToPullTargets(projectileSetup.MinCountToPullTargets);
               target.AddPullTargetHolderStatuses(new List<StatusSetup>(32))
                   .With(x => x.PullTargetHolderStatuses.AddRange(projectileSetup.StatusesContainer));
            }
        }
    }
}