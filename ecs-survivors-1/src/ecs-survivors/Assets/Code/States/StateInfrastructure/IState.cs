﻿namespace Code.States.StateInfrastructure
{
  public interface IState: IExitableState
  {
    void Enter();
  }
}