using System;
using UnityEngine;

public class DelegateWrapper
{
    public Action Action;

    public static DelegateWrapper operator +(DelegateWrapper wrapper, Action newAction)
    {
        wrapper.Action += newAction;
        return wrapper;
    }

    public static DelegateWrapper operator -(DelegateWrapper wrapper, Action newAction)
    {
        wrapper.Action -= newAction;
        return wrapper;
    }

    public void Invoke()
    {
        Action?.Invoke();
    }
}