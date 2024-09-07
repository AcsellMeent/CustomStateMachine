namespace Player
{
    public class RollState : PlayerMovementState
    {
        public RollState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider, AnimationClips animationClip) : base(stateMachine, transitions, componentProvider, animationClip) { }

        public override void Update()
        {
            base.Update();

            Move(ViewModel.forward, Specifications.RollSpeed);
        }
    }
}