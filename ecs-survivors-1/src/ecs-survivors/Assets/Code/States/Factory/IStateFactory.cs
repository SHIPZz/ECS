using Code.States.StateInfrastructure;

namespace Code.States.Factory
{
  public interface IStateFactory
  {
    T GetState<T>() where T : class, IExitableState;
  }
}