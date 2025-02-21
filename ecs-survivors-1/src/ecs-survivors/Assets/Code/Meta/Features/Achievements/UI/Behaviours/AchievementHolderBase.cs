using Code.Meta.Features.Achievements.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.Features.Achievements.UI.Behaviours
{
    public class AchievementHolderBase : MonoBehaviour
    {
        public AchievementTypeId Id;
        public TextMeshProUGUI Amount;

        private IAchievementService _achievementService;

        [Inject]
        private void Construct(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        private void Start()
        {
            _achievementService.OnAchievementChanged += UpdateValue;
            _achievementService.OnAchievementCompleted += SetNextAchievementOnCompleted;
        }

        private void OnDestroy()
        {
            _achievementService.OnAchievementChanged -= UpdateValue;
            _achievementService.OnAchievementCompleted -= SetNextAchievementOnCompleted;
        }

        private void UpdateValue(AchievementTypeId achievementTypeId, float currentValue)
        {
            if (achievementTypeId != Id)
                return;

            ShowValue(achievementTypeId, currentValue);
        }

        private void SetNextAchievementOnCompleted(AchievementTypeId id, AchievementConfig config)
        {
            if (Id != id)
                return;

            if (_achievementService.HasNext(Id))
            {
                UpdateValue(id, 0);
                return;
            }

            gameObject.SetActive(false);
        }

        protected virtual void ShowValue(AchievementTypeId achievementTypeId, float currentValue)
        {
            Amount.text = $"{currentValue}/{_achievementService.GetAchievementTargetAmount(achievementTypeId)}";
        }
    }
}