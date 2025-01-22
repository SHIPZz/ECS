using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusSetup statusSetup, int targetId, int producerId)
        {
            GameEntity status = null;

            Debug.Log($"{statusSetup.StatusTypeId}");
            
            switch (statusSetup.StatusTypeId)
            {
                case StatusTypeId.None:
                    break;
                
                case StatusTypeId.Freeze:
                    status = CreateFreezeStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;

                case StatusTypeId.Poison:
                    status = CreatePoisonStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.SpeedUp:
                    status = CreateSpeedUpStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.MaxHpIncrease:
                    status = CreateMaxHpStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                case StatusTypeId.Scale:
                    status = CreateScaleIncreaseStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;

                case StatusTypeId.Invulnerable:
                    status = CreateInvulnerableStatus(statusSetup, targetId, producerId, statusSetup.Value);
                    break;
                
                default:
                    throw new ArgumentException("no status");
            }

            return status
                    .With(x => x.AddDuration(statusSetup.Duration), when: statusSetup.Duration > 0)
                    .With(x => x.AddTimeLeft(statusSetup.Duration), when: statusSetup.Duration > 0)
                    .With(x => x.AddPeriod(statusSetup.Period), when: statusSetup.Period > 0)
                    .With(x => x.AddTimeSinceLastTick(0), when: statusSetup.Period > 0)
                ;
        }
        
        private GameEntity CreateInvulnerableStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isInvulnerableStatus = true);
        }

        private GameEntity CreateScaleIncreaseStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddTargetId(targetId)
                .AddEffectValue(value)
                .AddStatusTypeId(statusSetup.StatusTypeId)
                .AddProducerId(producerId)
                .With(x => x.isStatus = true)
                .With(x => x.isScaleIncrease = true);
        }

        private GameEntity CreateMaxHpStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isMaxHpIncrease = true)
                ;
        }
        
        private GameEntity CreatePoisonStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isPoison = true)
                ;
        }
        
        private GameEntity CreateSpeedUpStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isSpeedUp = true)
                ;
        }
        
        private GameEntity CreateFreezeStatus(StatusSetup statusSetup, int targetId, int producerId, float value)
        {
            return  CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddTargetId(targetId)
                    .AddEffectValue(value)
                    .AddStatusTypeId(statusSetup.StatusTypeId)
                    .AddProducerId(producerId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isFreeze = true)
                ;
        }
    }
}