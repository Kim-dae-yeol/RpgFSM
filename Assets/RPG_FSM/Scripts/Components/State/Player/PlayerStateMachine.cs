using System;
using RPG_FSM.Scripts.Domain;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

namespace RPG_FSM.Scripts.Components.State
{
    public class PlayerStateMachine : StateMachine<PlayerBaseState>
    {
        public Player Player { get; private set; }
        public PlayerInput PlayerInput { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerWalkState WalkState { get; private set; }
        public PlayerRunState RunState { get; private set; }

        public Vector3 MovementDirection { get; set; }
        public float MovementSpeed { get; private set; }
        public float RotationDamping { get; private set; }
        public float MovementSpeedModifier { get; set; } = 1f;

        public float JumpForce { get; set; }

        public Transform MainCameraTransform { get; set; }

        private void Awake()
        {
            Player = GetComponent<Player>();
            PlayerInput = GetComponent<PlayerInput>();
            if (Camera.main != null) MainCameraTransform = Camera.main.transform;
        }

        private void Start()
        {
            IdleState = new PlayerIdleState(this);
            RunState = new PlayerRunState(this);
            WalkState = new PlayerWalkState(this);
            AddInputActionCallback();
            MovementSpeed = Player.PlayerData.GroundData.WalkSpeedModifier;
            PlayerInput = Player.PlayerInput;
            TransitionTo(IdleState);
        }

        private void OnDestroy()
        {
            RemoveInputActionCallback();
        }

        private void AddInputActionCallback()
        {
            PlayerInput.PlayerActions.Move.started += OnMoveStarted;
            PlayerInput.PlayerActions.Move.canceled += OnMoveCanceled;

            PlayerInput.PlayerActions.Attack.started += OnAttackStarted;
            PlayerInput.PlayerActions.Jump.started += OnJumpStarted;
            PlayerInput.PlayerActions.Run.started += OnRunStarted;
        }

        private void OnMoveCanceled(InputAction.CallbackContext input)
        {
            if (input.ReadValue<Vector2>() != Vector2.zero)
            {
                TransitionTo(IdleState);
            }
        }

        private void RemoveInputActionCallback()
        {
            PlayerInput.PlayerActions.Move.started -= OnMoveStarted;
            PlayerInput.PlayerActions.Attack.started -= OnAttackStarted;
            PlayerInput.PlayerActions.Jump.started -= OnJumpStarted;
            PlayerInput.PlayerActions.Run.started -= OnRunStarted;
        }

        private void OnRunStarted(InputAction.CallbackContext obj)
        {
            TransitionTo(RunState);
        }

        private void OnJumpStarted(InputAction.CallbackContext obj)
        {
            //TransitionTo(JumpState);
        }

        private void OnAttackStarted(InputAction.CallbackContext obj)
        {
            //todo
        }

        private void OnMoveStarted(InputAction.CallbackContext input)
        {
            Vector2 direction = input.ReadValue<Vector2>();
            if (direction != Vector2.zero)
            {
                MovementDirection = GetMovementDirection(direction);
                TransitionTo(WalkState);
            }
            else
            {
                TransitionTo(IdleState);
            }
        }

        private Vector3 GetMovementDirection(Vector2 direction)
        {
            Vector3 forward = MainCameraTransform.forward;
            Vector3 right = MainCameraTransform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            return forward * direction.y + right * direction.x;
        }
    }
}