using System;
using UnityEngine;

namespace RPG_FSM.Scripts.Domain
{
    public class Player : MonoBehaviour
    {
        [field: Header("Animation Data")]
        [field: SerializeField]
        public PlayerAnimationData AnimationData { get; private set; }
        
        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public PlayerInput PlayerInput { get; private set; }
        public CharacterController Controller { get; private set; }

        private void Awake()
        {
            AnimationData.Initialize();
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponent<Animator>();
            PlayerInput = GetComponent<PlayerInput>();
            Controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}