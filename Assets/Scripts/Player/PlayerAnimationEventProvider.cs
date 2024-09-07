using UnityEngine;

namespace Player
{
    public class PlayerAnimationEventProvider : MonoBehaviour
    {
        public DelegateWrapper OnRollEnd = new DelegateWrapper();
        public DelegateWrapper OnAttackEnd = new DelegateWrapper();
        public DelegateWrapper OnAttackContinue = new DelegateWrapper();

        public void RollEnd() => OnRollEnd?.Invoke();
        public void AttackEnd() => OnAttackEnd?.Invoke();
        public void AttackContinue() => OnAttackContinue?.Invoke();
    }
}