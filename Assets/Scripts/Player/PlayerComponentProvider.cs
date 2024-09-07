using UnityEngine;

namespace Player
{
    public class PlayerComponentProvider : MonoBehaviour
    {
        private PlayerAnimationProvider _animationSwitcher;
        [SerializeField]
        private PlayerAnimationEventProvider _animationEventProvider;
        private PlayerInputProvider _inputProvider;
        private CharacterController _characterController;
        private PlayerDataProvider _dataProvider;
        private PlayerCombatProperties _combatProperties;
        [SerializeField]
        private Transform _viewModel;
        private Transform _cameraTransform;

        public PlayerAnimationProvider AnimationSwitcher { get => _animationSwitcher ??= GetComponent<PlayerAnimationProvider>(); }
        public PlayerAnimationEventProvider AnimationEventProvider { get => _animationEventProvider; }
        public PlayerInputProvider InputProvider { get => _inputProvider ??= GetComponent<PlayerInputProvider>(); }
        public CharacterController CharacterController { get => _characterController ??= GetComponent<CharacterController>(); }
        public PlayerDataProvider DataProvider { get => _dataProvider ??= GetComponent<PlayerDataProvider>(); }
        public PlayerCombatProperties CombatProperties { get => _combatProperties ??= GetComponent<PlayerCombatProperties>(); }
        public Transform ViewModel { get => _viewModel; }
        public Transform CameraTransform { get => _cameraTransform ??= Camera.main.transform; }
    }
}