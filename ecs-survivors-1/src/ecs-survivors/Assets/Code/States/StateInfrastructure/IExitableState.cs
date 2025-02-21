using RSG;

namespace Code.States.StateInfrastructure
{
  public interface IExitableState
  {
    IPromise BeginExit();
    void EndExit();
  }
}