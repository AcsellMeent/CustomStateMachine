using UnityEngine;

namespace Player
{
    public class IdleState : PlayerMovementState
    {
        public IdleState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            Move(new Vector3());
        }
    }
}
