using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Pull
{
    [Game] public class PullTargetList : IComponent { public List<int> Value; }
    
    [Game] public class PullTargetHolder : IComponent {  }
    
    [Game] public class MaxPullTargetHold : IComponent {  public int Value; }
    
}