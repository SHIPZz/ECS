using System;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Simulation;
using Code.Meta.SaveLoad;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.States.StateInfrastructure;
using Code.States.StateMachine;

namespace Code.States.GameStates
{
    public class ActualizeProgressState : SimpleState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IProgressProvider _progressProvider;
        private readonly ITimeService _timeService;
        private readonly ISystemFactory _systemFactory;
        private ActualizationFeature _actualizationFeature;
        private readonly TimeSpan _twoDays = TimeSpan.FromDays(2);
        private readonly ISaveLoadService _saveLoadService;

        public ActualizeProgressState(
            IGameStateMachine stateMachine,
            IProgressProvider progressProvider,
            ISaveLoadService saveLoadService,
            ISystemFactory systemFactory,
            ITimeService timeService
        )
        {
            _saveLoadService = saveLoadService;
            _systemFactory = systemFactory;
            _timeService = timeService;
            _stateMachine = stateMachine;
            _progressProvider = progressProvider;
        }

        public override void Enter()
        {
            _actualizationFeature = _systemFactory.Create<ActualizationFeature>();

            ActualizeProgress(_progressProvider.ProgressData);
            
            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        protected override void Exit()
        {
            _actualizationFeature.Cleanup();
            _actualizationFeature.TearDown();

            _actualizationFeature = null;
        }

        private void ActualizeProgress(ProgressData data)
        {
            _actualizationFeature.Initialize();
            _actualizationFeature.DeactivateReactiveSystems();

            DateTime until = GetLimitedUntilTime(data);

            while (data.LastSimulationTickTime < until)
            {
                MetaEntity tick = CreateMetaEntity
                    .Empty()
                    .AddTick(1f);

                _actualizationFeature.Execute();
                _actualizationFeature.Cleanup();
                
                tick.Destroy();
            }

            data.LastSimulationTickTime = _timeService.UtcNow;
            
            _saveLoadService.SaveProgress();
        }

        private DateTime GetLimitedUntilTime(ProgressData data)
        {
            if (_timeService.UtcNow - data.LastSimulationTickTime < _twoDays)
                return _timeService.UtcNow;

            return data.LastSimulationTickTime + _twoDays;
        }
    }
}