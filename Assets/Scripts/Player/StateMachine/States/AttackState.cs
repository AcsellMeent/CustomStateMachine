namespace Player
{
    public class AttackState : PlayerState
    {
        protected PlayerCombatProperties PlayerCombatProperties;
        protected bool CanContinue;
        public AttackState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider componentProvider) : base(stateMachine, transitions, componentProvider)
        {
            PlayerCombatProperties = ComponentProvider.CombatProperties;
        }

        public override void Enter()
        {
            base.Enter();
            AnimationProvider.StartAnimation(PlayerCombatProperties.CurrentAttack.AnimationClip);
            AnimationEventProvider.OnAttackContinue += OnAttackContinue;
            InputProvider.OnAttack += OnAttack;
        }

        private void OnAttackContinue()
        {
            CanContinue = true;
        }

        private void OnAttack()
        {
            if (CanContinue)
            {
                CanContinue = false;
                AnimationProvider.StopAnimation(PlayerCombatProperties.CurrentAttack.AnimationClip);
                PlayerCombatProperties.Next();
                AnimationProvider.StartAnimation(PlayerCombatProperties.CurrentAttack.AnimationClip);
            }
        }

        public override void Exit()
        {
            base.Exit();
            CanContinue = false;
            AnimationProvider.StopAnimation(PlayerCombatProperties.CurrentAttack.AnimationClip);
            AnimationEventProvider.OnAttackContinue -= OnAttackContinue;
            InputProvider.OnAttack -= OnAttack;
        }
    }
}
