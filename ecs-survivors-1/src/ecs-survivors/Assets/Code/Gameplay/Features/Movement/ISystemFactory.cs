using Entitas;

namespace Code.Gameplay.Features.Movement
{
    public interface ISystemFactory
    {
        T Create<T>() where T : ISystem;
    }
}