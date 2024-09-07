using System;

public class StateTransition<TState> : IStateTransition where TState : State
{
    public StateTransition(Func<bool> condition)
    {
        Condition = condition;
    }

    public StateTransition(DelegateWrapper wrapper)
    {
        _actionWrapper = wrapper;
    }

    public StateTransition(Func<bool> condition, DelegateWrapper wrapper) : this(condition)
    {
        _actionWrapper = wrapper;
    }

    private StateMachine _stateMachine;
    public readonly Func<bool> Condition;
    private DelegateWrapper _actionWrapper;
    private Action<IStateTransition> _onActionCalled;

    public void Init(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Execute() => _stateMachine.SwitchState<TState>();

    public bool Check() => Condition == null ? false : _actionWrapper == null ? Condition() : false;

    private void CheckAction()
    {
        if (Condition == null ? true : Condition())
        {
            _onActionCalled?.Invoke(this);
        }
    }

    public void Enable(Action<IStateTransition> callback)
    {
        if (_actionWrapper != null)
        {
            _actionWrapper += CheckAction;
            _onActionCalled += callback;
        }
    }

    public void Disable(Action<IStateTransition> callback)
    {
        if (_actionWrapper != null)
        {
            _actionWrapper -= CheckAction;
            _onActionCalled -= callback;
        }
    }

}