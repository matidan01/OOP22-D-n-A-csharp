namespace DnA {
    public class JumpCommand : ICommand
    {
        private readonly IPlayer player;

        public JumpCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (this.player.GetStateCopy()._stateX != State.StateEnum.STATE_JUMPING)
            {
                this.player.SetVectorY(-IPlayer.JUMPVELOCITY);
                this.player.SetStateX(State.StateEnum.STATE_JUMPING);
            }
        }
    }
}
