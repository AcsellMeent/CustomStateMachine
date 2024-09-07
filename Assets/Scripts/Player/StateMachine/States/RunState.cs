namespace Player
{
    public class RunState : PlayerMovementState
    {
        public RunState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            RotateTowardsTargetRotation();

            Move(_targetDirection, Specifications.RunSpeed);
        }
    }
}

