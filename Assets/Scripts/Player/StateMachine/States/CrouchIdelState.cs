using UnityEngine;

namespace Player
{
    public class CrouchIdleState : PlayerMovementState
    {
        public CrouchIdleState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            Move(new Vector3());
        }
    }
}
