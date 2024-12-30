using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IInputService _inputService;

        public EmitInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_inputService.HasAxisInput())
                    entity.ReplaceAxisInput(new Vector3(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis(),
                        0));
                else if(entity.hasAxisInput)
                    entity.RemoveAxisInput();
            }
        }
    }
}