using RPG_FSM.Scripts.Domain;

namespace RPG_FSM.Scripts.Components.State
{
    public class PlayerRunState : PlayerBaseState
    {
        public override float MovementSpeed =>
            base.MovementSpeed + StateMachine.Player.PlayerData.GroundData.RunSpeedModifier;

        public PlayerRunState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            animator.SetBool(StateMachine.Player.AnimationData.RunParameterHash, true);
        }

        public override void Exit()
        {
            base.Exit();
            animator.SetBool(StateMachine.Player.AnimationData.RunParameterHash, false);
        }
    }
}