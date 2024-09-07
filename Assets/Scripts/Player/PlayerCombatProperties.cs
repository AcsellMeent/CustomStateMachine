using System;
using UnityEngine;

namespace Player
{
    public class PlayerCombatProperties : MonoBehaviour
    {
        [SerializeField]
        private Attack[] Attacks;
        public int CurrentAttackIndex { get; private set; }
        public Attack CurrentAttack { get => Attacks[CurrentAttackIndex]; }

        public void Next()
        {
            if (CurrentAttackIndex < Attacks.Length - 1)
            {
                CurrentAttackIndex++;
            }
            else
            {
                Reset();
            }
        }

        public void Reset()
        {
            CurrentAttackIndex = 0;
        }
    }

    [Serializable]
    public class Attack
    {
        public AnimationClips AnimationClip;
    }
}