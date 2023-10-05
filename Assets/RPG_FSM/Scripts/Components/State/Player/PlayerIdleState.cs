using UnityEngine.InputSystem;

namespace RPG_FSM.Scripts.Components.State
{
    public class PlayerIdleState : PlayerBaseState
    {





        public override void Update()
        {
        }

        public override void PhysicsUpdate()
        {
        }

        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            
        }
    }
}