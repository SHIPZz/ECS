using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Entitas;

namespace Code.Gameplay.Cameras
{
    public class CameraFollowHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private ICameraProvider _cameraProvider;

        public CameraFollowHeroSystem(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                _cameraProvider.MainCamera.transform.SetWorldXY(entity.WorldPosition.x, entity.WorldPosition.y);
            }
        }
    }
}