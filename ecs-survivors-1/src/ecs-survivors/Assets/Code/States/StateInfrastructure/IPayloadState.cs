namespace Code.States.StateInfrastructure
{
  public interface IPayloadState<TPayload> : IExitableState
  {
    void Enter(TPayload payload);
  }
}