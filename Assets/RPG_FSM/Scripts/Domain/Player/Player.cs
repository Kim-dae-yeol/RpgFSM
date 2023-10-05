using System;
using RPG_FSM.Scriptable_Objects.Player.PlayerSOScripts;
using RPG_FSM.Scripts.Components.State;
using UnityEngine;

namespace RPG_FSM.Scripts.Domain
{
    public class Player : MonoBehaviour
    {
        [field: Header("Animation Data")]
        [field: SerializeField]
        public PlayerAnimationData AnimationData { get; private set; }

        private PlayerStateMachine _stateMachine;

        [field: SerializeField] public PlayerDataSo PlayerData { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public PlayerInput PlayerInput { get; private set; }
        public CharacterController Controller { get; private set; }

        private void Awake()
        {
            AnimationData.Initialize();
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponentInChildren<Animator>();
            PlayerInput = GetComponent<PlayerInput>();
            Controller = GetComponent<CharacterController>();
            _stateMachine = GetComponent<PlayerStateMachine>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}