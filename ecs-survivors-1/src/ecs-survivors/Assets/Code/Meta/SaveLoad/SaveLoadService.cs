using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Meta.Factory;
using Code.Progress;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Meta.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "PlayerProgress";
        private readonly MetaContext _meta;
        private readonly IProgressProvider _progressProvider;
        private readonly IMetaFactory _metaFactory;
        private readonly ITimeService _timeService;

        public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);

        public SaveLoadService(MetaContext meta,
            IProgressProvider progressProvider,
            ITimeService timeService,
            IMetaFactory metaFactory)
        {
            _timeService = timeService;
            _metaFactory = metaFactory;
            _meta = meta;
            _progressProvider = progressProvider;
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData()
            {
                LastSimulationTickTime = _timeService.UtcNow
            });

            _metaFactory.CreateGold();
            _metaFactory.CreateEnergy();
            _metaFactory.CreateRollTimer();
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();

            PlayerPrefs.SetString(ProgressKey, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            var serializedProgress = PlayerPrefs.GetString(ProgressKey);
            

            HydrateProgress(serializedProgress);
        }

        private void HydrateProgress(string serializedProgress)
        {
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.MetaEntitySnapshots;

            HydrateMetaEntities(snapshots);
        }

        private void HydrateMetaEntities(List<EntitySnapshot> snapshots)
        {
            foreach (EntitySnapshot snapshot in snapshots)
            {
                _meta
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider
                .ProgressData
                .EntityData.MetaEntitySnapshots = _meta.GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private bool RequiresSave(MetaEntity metaEntity)
        {
            return metaEntity
                .GetComponents()
                .Any(x => x is ISavedComponent);
        }
    }
}