namespace Player
{
    public class WalkState : PlayerMovementState
    {
        public WalkState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            RotateTowardsTargetRotation();

            Move(_targetDirection, Specifications.WalkSpeed);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
