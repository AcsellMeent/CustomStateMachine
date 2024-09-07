using System;
using UnityEngine;

public class HumanoidAnimationEvents : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnShoot;
    public event Action OnFootR;
    public event Action OnFootL;
    public event Action OnLand;

    public void Hit() => OnHit?.Invoke();
    public void Shoot() => OnShoot?.Invoke();
    public void FootR() => OnFootR?.Invoke();
    public void FootL() => OnFootL?.Invoke();
    public void Land() => OnLand?.Invoke();
}
