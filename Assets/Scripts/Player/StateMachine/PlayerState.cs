namespace Player
{
    public abstract class PlayerState : State
    {
        protected PlayerComponentProvider ComponentProvider;
        protected PlayerAnimationProvider AnimationProvider;
        protected PlayerAnimationEventProvider AnimationEventProvider;
        protected PlayerInputProvider InputProvider;
        public PlayerState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider ComponentProvider) : base(stateMachine, transitions)
        {
            this.ComponentProvider = ComponentProvider;
            AnimationProvider = ComponentProvider.AnimationSwitcher;
            AnimationEventProvider = ComponentProvider.AnimationEventProvider;
            InputProvider = ComponentProvider.InputProvider;
        }
    }
}