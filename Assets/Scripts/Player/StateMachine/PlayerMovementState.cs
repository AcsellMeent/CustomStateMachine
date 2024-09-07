using UnityEngine;

namespace Player
{
    public abstract class PlayerMovementState : PlayerState
    {
        protected CharacterController CharacterController;
        protected Transform ViewModel;
        protected AnimationClips AnimationClip;
        protected Transform CameraTransform;
        protected PlayerSpecifications Specifications;
        protected PlayerProperties Properties;
        protected Vector3 _targetDirection;
        private float _dampVelocity;

        protected PlayerMovementState(StateMachine stateMachine, IStateTransition[] transitions, PlayerComponentProvider ComponentProvider, AnimationClips animationClip) : base(stateMachine, transitions, ComponentProvider)
        {
            CharacterController = ComponentProvider.CharacterController;
            ViewModel = ComponentProvider.ViewModel;
            AnimationClip = animationClip;
            CameraTransform = ComponentProvider.CameraTransform;
            Specifications = ComponentProvider.DataProvider.Specifications;
            Properties = ComponentProvider.DataProvider.Properties;
        }

        public override void Enter()
        {
            AnimationProvider.StartAnimation(AnimationClip);
        }

        // public override bool IsReadyForTransition() => AnimationProvider.CheckCurrentClip(AnimationClip);

        public override void Exit()
        {
            base.Exit();
            AnimationProvider.StopAnimation(AnimationClip);
        }

        protected void Move(Vector3 direction, float speed = 1)
        {
            CharacterController.SimpleMove(direction * speed);
        }

        protected void RotateTowardsTargetRotation()
        {
            Vector3 cameraDirection = ViewModel.position - CameraTransform.position;
            cameraDirection.y = 0;
            cameraDirection = cameraDirection.normalized;

            _targetDirection = CameraTransform.right * InputProvider.MoveInputNormalized.x + cameraDirection * InputProvider.MoveInputNormalized.y;

            Vector3 rayOffset = ViewModel.position + new Vector3(0, 0.1f, 0);

            Debug.DrawRay(rayOffset, _targetDirection, Color.red);
            Debug.DrawRay(rayOffset, new Vector3(InputProvider.MoveInput.x, 0, InputProvider.MoveInput.y), Color.blue);

            float targetAngle = Mathf.Atan2(_targetDirection.x, _targetDirection.z) * Mathf.Rad2Deg;
            targetAngle = targetAngle < 0 ? targetAngle + 360 : targetAngle;

            float dampedAngle = Mathf.SmoothDampAngle(ViewModel.eulerAngles.y, targetAngle, ref _dampVelocity, 0.1f);
            ViewModel.rotation = Quaternion.Euler(0, dampedAngle, 0);
        }
    }
}