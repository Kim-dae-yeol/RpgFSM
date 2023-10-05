using UnityEngine;

namespace RPG_FSM.Scripts.Components.State
{
    public abstract class PlayerBaseState : IState
    {
        public virtual float MovementSpeed => StateMachine.MovementSpeed;
        public PlayerStateMachine StateMachine { get; private set; }
        protected PlayerInput PlayerInput;
        protected Animator animator;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            PlayerInput = stateMachine.Player.PlayerInput;
            animator = StateMachine.Player.Animator;
        }


        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            Quaternion targetRotation = Quaternion.LookRotation(StateMachine.MovementDirection);
            Quaternion rotation = Quaternion.Slerp(StateMachine.transform.rotation, targetRotation,
                Time.deltaTime * StateMachine.Player.PlayerData.GroundData.BaseRotationDamping);
            StateMachine.transform.rotation = rotation;
        }

        public virtual void PhysicsUpdate()
        {
        }
    }
}