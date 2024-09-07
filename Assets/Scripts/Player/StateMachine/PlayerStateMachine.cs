using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerComponentProvider))]
    public class PlayerStateMachine : StateMachine
    {
        private PlayerComponentProvider _componentProvider;
        private PlayerInputProvider _inputProvider;
        private PlayerAnimationEventProvider _animationEventProvider;

        private void Awake()
        {
            _componentProvider = GetComponent<PlayerComponentProvider>();
            _inputProvider = _componentProvider.InputProvider;
            _animationEventProvider = _componentProvider.AnimationEventProvider;

            States = new List<State>{
                new IdleState(this, new IStateTransition[]{
                    new StateTransition<RunState>(() => _inputProvider.IsRunning),
                    new StateTransition<WalkState>(() => _inputProvider.IsMoving),
                    new StateTransition<CrouchIdleState>(_inputProvider.OnCrouch),
                    new StateTransition<AttackState>(_inputProvider.OnAttack),
                },_componentProvider, AnimationClips.Idle),

                new WalkState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(() => !_inputProvider.IsMoving),
                    new StateTransition<RunState>(() => _inputProvider.IsRunning),
                    new StateTransition<CrouchWalkState>(_inputProvider.OnCrouch),
                },_componentProvider, AnimationClips.Walk),

                new RunState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(() => !_inputProvider.IsMoving),
                    new StateTransition<WalkState>(() => !_inputProvider.IsRunning),
                    new StateTransition<SprintState>(() => _inputProvider.IsSprinting),
                    new StateTransition<RollState>(_inputProvider.OnRolling),
                    new StateTransition<CrouchWalkState>(_inputProvider.OnCrouch),
                    new StateTransition<AttackState>(_inputProvider.OnAttack),
                },_componentProvider, AnimationClips.Run),

                new SprintState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(() => !_inputProvider.IsMoving),
                    new StateTransition<RunState>(() => !_inputProvider.IsSprinting),
                    new StateTransition<RollState>(_inputProvider.OnRolling),
                }, _componentProvider, AnimationClips.Sprint),

                new CrouchIdleState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(_inputProvider.OnCrouch),
                    new StateTransition<CrouchWalkState>(() => _inputProvider.IsMoving, _inputProvider.OnMoveUpdate),
                }, _componentProvider, AnimationClips.CrouchIdle),

                new CrouchWalkState(this, new IStateTransition[]{
                    new StateTransition<WalkState>(_inputProvider.OnCrouch),
                    new StateTransition<CrouchIdleState>(() => !_inputProvider.IsMoving, _inputProvider.OnMoveUpdate),
                }, _componentProvider, AnimationClips.CrouchWalk),

                new RollState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(_animationEventProvider.OnRollEnd),
                }, _componentProvider, AnimationClips.Roll),

                new AttackState(this, new IStateTransition[]{
                    new StateTransition<IdleState>(_animationEventProvider.OnAttackEnd),
                }, _componentProvider),
            };

            CurentState = States[0];
            CurentState.Enter();
        }
    }
}
