namespace Player
{
    public class CrouchWalkState : PlayerMovementState
    {
        public CrouchWalkState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            RotateTowardsTargetRotation();

            Move(_targetDirection, Specifications.CrouchWalkSpeed);
        }
    }
}
