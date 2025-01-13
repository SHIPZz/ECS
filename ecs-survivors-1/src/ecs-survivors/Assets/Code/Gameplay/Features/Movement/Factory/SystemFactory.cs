using Entitas;
using Zenject;

namespace Code.Gameplay.Features.Movement.Factory
{
    public class SystemFactory : ISystemFactory
    {
        private IInstantiator _instantiator;

        public SystemFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create<T>() where T : ISystem
        {
            return _instantiator.Instantiate<T>();
        }
    }
}