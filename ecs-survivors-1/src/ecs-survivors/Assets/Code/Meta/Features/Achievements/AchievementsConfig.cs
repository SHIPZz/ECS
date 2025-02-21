using System;
using System.Collections.Generic;
using Code.Meta.Features.Achievements;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementsConfig", menuName = "AchievementsConfig")]
public class AchievementsConfig : ScriptableObject
{
    public List<AchievementGroup> AchievementConfigs;
}

[Serializable]
public class AchievementGroup
{
    public AchievementTypeId Id;

    public List<AchievementConfig> Configs;
}