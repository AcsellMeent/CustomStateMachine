using System;

public interface IStateTransition
{
    public void Init(StateMachine stateMachine);
    public void Enable(Action<IStateTransition> action);
    public void Disable(Action<IStateTransition> action);
    public void Execute();
    public bool Check();
}
