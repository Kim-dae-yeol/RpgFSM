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
            base.Enter();
            animator.SetBool(StateMachine.Player.AnimationData.WalkParameterHash, true);
        }

        public override void Exit()
        {
            base.Exit();
            animator.SetBool(StateMachine.Player.AnimationData.WalkParameterHash, false);
        }

        public override void Update()
        {
            base.Update();
            
        }

        public override void PhysicsUpdate()
        {
        }
    }
}