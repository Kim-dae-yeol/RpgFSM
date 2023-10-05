namespace RPG_FSM.Scripts.Components.State
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Update();
        public void PhysicsUpdate();
    }
}