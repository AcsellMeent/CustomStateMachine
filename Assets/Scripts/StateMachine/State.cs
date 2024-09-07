public abstract class State
{
    public State(StateMachine stateMachine, IStateTransition[] transitions)
    {
        _stateMachine = stateMachine;
        _transitions = transitions;

        for (int i = 0; i < _transitions.Length; i++)
        {
            _transitions[i].Init(stateMachine);
        }
    }
    private StateMachine _stateMachine;
    private IStateTransition[] _transitions;

    private bool _onTransitionReadyWasCalled;

    public virtual void Enter() { }

    public virtual void Update()
    {
        if (IsReadyForTransition())
        {
            if (!_onTransitionReadyWasCalled) { OnTransitionReady(); }
            CheckingTransitionConditions();
        }
    }

    public virtual void CheckingTransitionConditions()
    {
        if (_transitions == null) return;

        for (int i = 0; i < _transitions.Length; i++)
        {
            if (_transitions[i].Check())
            {
                _transitions[i].Execute();
                break;
            }
        }
    }

    public virtual bool IsReadyForTransition() => true;

    public virtual void OnTransitionReady()
    {
        _onTransitionReadyWasCalled = true;
        for (int i = 0; i < _transitions.Length; i++)
        {
            _transitions[i].Enable(OnTransitionAction);
        }
    }

    private void OnTransitionAction(IStateTransition stateTransition)
    {
        stateTransition.Execute();
    }

    public virtual void Exit()
    {
        _onTransitionReadyWasCalled = false;
        for (int i = 0; i < _transitions.Length; i++)
        {
            _transitions[i].Disable(OnTransitionAction);
        }
    }
}
