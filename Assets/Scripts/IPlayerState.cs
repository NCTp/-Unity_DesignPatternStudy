namespace Player
{
    public interface IPlayerState
    {
        void Handle(PlayerController controller);
        void Exit();
    }

}
