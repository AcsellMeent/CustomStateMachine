using Player;
using TMPro;
using UnityEngine;
using Zenject;

public class StateMachineDebug : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    private StateMachine _stateMachine;
    private State _previousState;

    [Inject]
    public void Construct(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _stateMachine.OnStateSwitched += OnStateSwitched;
    }

    private void OnStateSwitched(State state)
    {
        string debugMessage = $"{_previousState?.ToString()} > {state?.ToString()}";
        _text.text = debugMessage;
        _previousState = state;
    }

    private void OnDisable()
    {
        _stateMachine.OnStateSwitched -= OnStateSwitched;
    }
}
