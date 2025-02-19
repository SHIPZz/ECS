using UnityEngine;

namespace Code.Meta.Features.Achievements
{
    [CreateAssetMenu(fileName = "AchievementConfig", menuName = "AchievementConfig")]
    public class AchievementConfig : ScriptableObject
    {
        public float TargetAmount;
        public Sprite Icon;
    }
}