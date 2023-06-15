namespace DnA {
    public class RightCommand : ICommand
    {
        private readonly IPlayer player;

        public RightCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            this.player.SetVectorX(IPlayer.STANDARDVELOCITY);
            this.player.SetStateY(State.StateEnum.STATE_RIGHT);
        }
    }
}