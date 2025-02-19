using Code.Meta.Features.Achievements.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.Features.Achievements.UI.Behaviours
{
    public class GoldAchievementHolder : MonoBehaviour
    {
        public TextMeshProUGUI Amount;

        private IAchievementService _achievementService;

        [Inject]
        private void Construct(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        private void Start()
        {
            _achievementService.OnAchievementChanged += UpdateGold;
            _achievementService.OnAchievementCompleted += SetNextAchievementOnCompleted;
        }

        private void OnDestroy()
        {
            _achievementService.OnAchievementChanged -= UpdateGold;
            _achievementService.OnAchievementCompleted -= SetNextAchievementOnCompleted;
        }

        private void UpdateGold(AchievementTypeId achievementTypeId, float currentValue)
        {
            if (achievementTypeId != AchievementTypeId.Gold)
                return;
            
            Amount.text = $"{currentValue}/{_achievementService.GetAchievementTargetAmount(achievementTypeId)}";
        }

        private void SetNextAchievementOnCompleted(AchievementTypeId id, AchievementConfig config)
        {
            if (id == AchievementTypeId.Gold && _achievementService.HasNext(id)) 
                UpdateGold(id, 0);
            else
                gameObject.SetActive(false);
        }
    }
}