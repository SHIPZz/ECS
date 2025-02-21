using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Meta.Features.Achievements.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly Dictionary<AchievementTypeId, List<AchievementProgress>> _achievementProgress = new();
        private readonly Dictionary<AchievementTypeId, int> _achievementCurrentIds = new();
        private readonly AchievementsConfig _achievementsConfig;

        public event Action<AchievementTypeId, AchievementConfig> OnAchievementCompleted;
        public event Action<AchievementTypeId, float> OnAchievementChanged;

        public AchievementsConfig AchievementsConfig => _achievementsConfig;

        public AchievementService(AchievementsConfig achievementsConfig)
        {
            _achievementsConfig = achievementsConfig;
        }

        public void InitializeAchievements()
        {
            foreach (AchievementGroup group in _achievementsConfig.AchievementConfigs)
            {
                var progressList = new List<AchievementProgress>();

                foreach (AchievementConfig config in group.Configs)
                {
                    progressList.Add(new AchievementProgress(config, group.Id));
                }

                _achievementProgress[group.Id] = progressList;
                _achievementCurrentIds[group.Id] = 1;
            }
        }

        public void UpdateAchievement(AchievementTypeId id, float value)
        {
            if (!_achievementProgress.ContainsKey(id))
                throw new ArgumentException($"Achievement type {id} not found.");

            List<AchievementProgress> progressList = _achievementProgress[id];

            var achievementId = GetAchievementId(id);

            if (progressList.Count < achievementId)
                return;

            foreach (AchievementProgress progress in progressList)
            {
                if (progress.IsCompleted)
                    continue;

                progress.CurrentValue = value;

                OnAchievementChanged?.Invoke(id, progress.CurrentValue);

                MarkCompleted(id, progress);
            }
        }

        public AchievementProgress GetAchievementProgress(AchievementTypeId id)
        {
            List<AchievementProgress> achievementProgresses = GetAchievementsProgress(id);

            var achievementCurrentId = GetAchievementId(id);

            Debug.Log($"{achievementCurrentId}");
            Debug.Log($"{achievementProgresses.Count}");
            
            return achievementCurrentId >= achievementProgresses.Count
                ? null
                : achievementProgresses[achievementCurrentId];
        }

        public float GetAchievementTargetAmount(AchievementTypeId id)
        {
            return GetAchievementProgress(id).TargetAmount;
        }

        public bool HasNext(AchievementTypeId id)
        {
            AchievementProgress achievementProgress = GetAchievementProgress(id);

            return achievementProgress != null;
        }

        public List<AchievementProgress> GetAchievementsProgress(AchievementTypeId id)
        {
            if (_achievementProgress.TryGetValue(id, out var progressList))
            {
                return progressList;
            }

            throw new ArgumentException($"Achievement type {id} not found.");
        }

        private void MarkCompleted(AchievementTypeId id, AchievementProgress progress)
        {
            if (progress.CurrentValue >= progress.TargetAmount)
            {
                progress.IsCompleted = true;
                _achievementCurrentIds[id]++;
                OnAchievementCompleted?.Invoke(id, progress.Config);
            }
        }

        private int GetAchievementId(AchievementTypeId id)
        {
            var achievementCurrentId = _achievementCurrentIds[id] - 1;

            return Mathf.Clamp(achievementCurrentId, 0, achievementCurrentId);
        }
    }
}