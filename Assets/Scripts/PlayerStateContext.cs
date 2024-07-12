namespace Player
{
    public class PlayerStateContext
    {
        public IPlayerState CurrentState
        {
            get; set;
        }
        private readonly PlayerController _playerController;

        public PlayerStateContext(PlayerController playerController)
        {
            _playerController = playerController;
        }
        void Awake()
        {
            
        }

        public void Transition()
        {
            //CurrentState.Exit();
            CurrentState.Handle(_playerController);
        }
        public void Transition(IPlayerState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Handle(_playerController); 

        }
    }
}
