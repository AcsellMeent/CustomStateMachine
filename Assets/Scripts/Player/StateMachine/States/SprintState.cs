namespace Player
{
    public class SprintState : PlayerMovementState
    {
        public SprintState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            RotateTowardsTargetRotation();

            Move(ViewModel.forward, Specifications.SprintSpeed);
        }
    }
}
