using UnityEngine;

namespace RPG_FSM.Scripts.Components.State
{
    public class PlayerWalkState : PlayerBaseState
    {
        private Vector3 _moveDirection;
        
        public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            animator.SetBool(StateMachine.Player.AnimationData.WalkParameterHash, true);
            base.Enter();
        }

        public override void Exit()
        {
            animator.SetBool(StateMachine.Player.AnimationData.WalkParameterHash, false);
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _moveDirection = StateMachine.MovementDirection;
            StateMachine.Player.Controller.Move(_moveDirection * MovementSpeed * Time.deltaTime);
        }

        public override void PhysicsUpdate()
        {
        }
    }
}