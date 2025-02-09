using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> _entities;
        private readonly IInputService _inputService;

        public EmitInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _entities = input.GetGroup(InputMatcher
                .AllOf(InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (InputEntity entity in _entities)
            {
                if (_inputService.HasAxisInput())
                    entity.ReplaceAxisInput(new Vector3(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis(), 0));
                else if(entity.hasAxisInput)
                    entity.RemoveAxisInput();
            }
        }
    }
}