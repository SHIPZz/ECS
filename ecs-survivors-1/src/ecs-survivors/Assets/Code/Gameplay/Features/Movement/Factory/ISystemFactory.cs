using Entitas;

namespace Code.Gameplay.Features.Movement.Factory
{
    public interface ISystemFactory
    {
        T Create<T>() where T : ISystem;
    }
}