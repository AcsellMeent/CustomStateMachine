using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum AnimationClips { Idle, CrouchIdle, Walk, CrouchWalk, Run, Sprint, Roll, Attack_1, Attack_2 };
    public enum AnimationParameters { WALKSPEED };

    public class PlayerAnimationProvider : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private readonly Dictionary<AnimationClips, int> _animationClipsDictionary = new Dictionary<AnimationClips, int>()
        {
            {AnimationClips.Idle, Animator.StringToHash("Idle")},
            {AnimationClips.CrouchIdle, Animator.StringToHash("CrouchIdle")},
            {AnimationClips.Walk, Animator.StringToHash("Walk")},
            {AnimationClips.CrouchWalk, Animator.StringToHash("CrouchWalk")},
            {AnimationClips.Run, Animator.StringToHash("Run")},
            {AnimationClips.Sprint, Animator.StringToHash("Sprint")},
            {AnimationClips.Roll, Animator.StringToHash("Roll")},
            {AnimationClips.Attack_1, Animator.StringToHash("Attack_1")},
            {AnimationClips.Attack_2, Animator.StringToHash("Attack_2")},
        };

        private readonly Dictionary<AnimationParameters, int> _animationParametersDictionary = new Dictionary<AnimationParameters, int>()
        {
            {AnimationParameters.WALKSPEED, Animator.StringToHash("WalkSpeed")},
        };

        public void SetParameter(AnimationParameters parameter, float value)
        {
            if (!_animationParametersDictionary.ContainsKey(parameter)) throw new Exception($"Animation parameter dictionary doesn't contain {parameter}");
            _animator.SetFloat(_animationParametersDictionary[parameter], value);
        }

        public void StartAnimation(AnimationClips clip)
        {
            if (!_animationClipsDictionary.ContainsKey(clip)) throw new Exception($"Animation clips dictionary doesn't contain {clip}");
            _animator.SetBool(_animationClipsDictionary[clip], true);
        }

        public void StopAnimation(AnimationClips clip)
        {
            if (!_animationClipsDictionary.ContainsKey(clip)) throw new Exception($"Animation clips dictionary doesn't contain {clip}");
            _animator.SetBool(_animationClipsDictionary[clip], false);
        }

        public bool CheckCurrentClip(AnimationClips clip)
        {
            return _animationClipsDictionary[clip] == _animator.GetCurrentAnimatorStateInfo(0).shortNameHash;
        }
    }
}