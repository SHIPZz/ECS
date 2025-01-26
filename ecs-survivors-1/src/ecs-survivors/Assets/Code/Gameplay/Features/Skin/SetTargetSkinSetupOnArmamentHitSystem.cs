using Code.Gameplay.Features.Statuses;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Skin
{
    public class SetTargetSkinSetupOnArmamentHitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private readonly IGroup<GameEntity> _targets;
        private readonly GameContext _game;

        public SetTargetSkinSetupOnArmamentHitSystem(GameContext game)
        {
            _game = game;
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.StatusSetups,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.Reached
                    ));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.Id, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _armaments)
            foreach (int targetId in entity.TargetsBuffer)
            foreach (StatusSetup status in entity.StatusSetups)
            {
                GameEntity target = _game.GetEntityWithId(targetId);
                
                if(!_targets.ContainsEntity(target))
                    continue;
                
                if(status.TargetSkinSetup == null)
                    continue;
                
                if (status.TargetSkinSetup.TargetSkin != null) 
                    target.ReplaceTargetSprite(status.TargetSkinSetup.TargetSkin);

                if (status.TargetSkinSetup.AnimatorController != null)
                    target.ReplaceNewSkinAnimator(status.TargetSkinSetup.AnimatorController);
            }
        }
    }
}