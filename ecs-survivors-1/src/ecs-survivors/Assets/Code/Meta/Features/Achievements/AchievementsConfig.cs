using System;
using System.Collections.Generic;
using Code.Meta.Features.Achievements;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementsConfig", menuName = "AchievementsConfig")]
public class AchievementsConfig : ScriptableObject
{
    public List<AchievementGroup> AchievementConfigs;
    
    public List<AchievementConfig> GetConfigsByType(AchievementTypeId type)
    {
        foreach (var group in AchievementConfigs)
        {
            if (group.Id == type)
            {
                return group.Configs;
            }
        }
        
        return null; 
    }
}

[Serializable]
public class AchievementGroup
{
    public AchievementTypeId Id;

    public List<AchievementConfig> Configs;
}