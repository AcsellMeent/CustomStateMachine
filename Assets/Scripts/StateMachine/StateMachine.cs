using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected List<State> States = new List<State>();
    protected State CurentState;

    public event Action<State> OnStateSwitched;

    private void Update()
    {
        CurentState?.Update();
    }

    public void SwitchState<T>() where T : State
    {
        State newState = States.FirstOrDefault(s => s is T);
        if (newState == null) throw new Exception($"State machine doesn't contain {typeof(T)}");
        //Debug
        string debugMessage = $"{CurentState?.ToString()} > {newState?.ToString()}";
        Debug.Log(debugMessage);
        //Debug
        CurentState?.Exit();
        CurentState = newState;
        CurentState.Enter();
        OnStateSwitched?.Invoke(CurentState);
    }
}
