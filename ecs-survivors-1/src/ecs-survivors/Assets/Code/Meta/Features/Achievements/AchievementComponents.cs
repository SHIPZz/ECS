using Code.Progress;

namespace Code.Meta.Features.Achievements
{
    [Meta] public class AchievementTypeIdComponent : ISavedComponent { public AchievementTypeId Value; }
    
    [Meta] public class TargetAmount : ISavedComponent { public float Value; }
    
    [Meta] public class CurrentAmount : ISavedComponent { public float Value; }
    
    [Meta] public class Completed : ISavedComponent {  }
    
    [Meta] public class Achievement : ISavedComponent {  }
}