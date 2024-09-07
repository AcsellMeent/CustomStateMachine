using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputProvider : MonoBehaviour
    {
        private PlayerInputActions _inputAction;
        public DelegateWrapper OnMoveUpdate = new DelegateWrapper();
        public DelegateWrapper OnRolling = new DelegateWrapper();
        public DelegateWrapper OnCrouch = new DelegateWrapper();
        public DelegateWrapper OnAttack = new DelegateWrapper();

        private PlayerComponentProvider _componentProvider;
        private PlayerProperties _properties;

        public Vector2 MoveInput { get; private set; }
        public Vector2 MoveInputNormalized { get => MoveInput.normalized; }
        public bool IsMoving { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsSprinting { get; private set; }

        private void Awake()
        {
            _inputAction = new PlayerInputActions();

            _inputAction.Gameplay.Move.performed += OnMoveInput;
            _inputAction.Gameplay.Move.canceled += OnMoveInput;

            _inputAction.Gameplay.Sprint.performed += context => { IsSprinting = true; };
            _inputAction.Gameplay.Sprint.canceled += context => { IsSprinting = false; };

            _inputAction.Gameplay.Rolling.performed += context => { OnRolling?.Invoke(); };

            _inputAction.Gameplay.Crouch.performed += context => { OnCrouch?.Invoke(); };

            _inputAction.Gameplay.Attack.performed += context => { OnAttack?.Invoke(); };

            _componentProvider = GetComponent<PlayerComponentProvider>();

            _properties = _componentProvider.DataProvider.Properties;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
            IsMoving = MoveInput.magnitude > _properties.MoveThreshold;
            IsRunning = MoveInput.magnitude > _properties.RunThreshold;

            OnMoveUpdate?.Invoke();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }
    }
}
