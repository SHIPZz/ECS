using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviour
{
    public class ExperienceMeter : MonoBehaviour
    {
        public Slider ProgressBar;
        public Image Fill;

        public void SetExperience(float experience, float experienceForLevelUp)
        {
            Fill.type = Image.Type.Tiled;
            ProgressBar.value = experience / experienceForLevelUp;
        }
    }
}