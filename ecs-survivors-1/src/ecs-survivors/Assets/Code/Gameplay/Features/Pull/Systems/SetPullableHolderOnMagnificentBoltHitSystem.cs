using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Pull.Systems
{
    public class SetPullableHolderOnMagnificentBoltHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _magnificentBolt;
        private readonly GameContext _game;

        public SetPullableHolderOnMagnificentBoltHitSystem(GameContext game)
        {
            _game = game;
            _magnificentBolt = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.MagnificentBoltArmament,
                    GameMatcher.LastCollectedId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _magnificentBolt)
            {
               GameEntity target = _game.GetEntityWithId(armament.LastCollectedId);
               
               if(target.isPullTargetHolder)
                   continue;

               target.isPullTargetHolder = true;
               target.AddPullTargetList(new List<int>(32));
               target.AddMaxPullTargetHold(3);
            }
        }
    }
}