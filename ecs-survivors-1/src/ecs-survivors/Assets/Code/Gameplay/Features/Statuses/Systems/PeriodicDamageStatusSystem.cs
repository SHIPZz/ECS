using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _timeService;
        private readonly IEffectFactory _effectFactory;

        public PeriodicDamageStatusSystem(GameContext game, ITimeService timeService, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _timeService = timeService;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Period,
                    GameMatcher.TimeSinceLastTick,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _timeService.DeltaTime);
                }
                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);

                    Debug.Log($"damage");
                    
                    _effectFactory.CreateEffect(EffectSetup.Create(EffectTypeId.Damage, status.EffectValue),
                        status.TargetId, status.ProducerId);
                }
            }
        }
    }
}