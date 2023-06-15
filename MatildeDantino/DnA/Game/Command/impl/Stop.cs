namespace DnA {
    public class StopCommand : ICommand
    {
        private readonly IPlayer player;

        public StopCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            this.player.SetVectorX(0);
            this.player.SetStateY(State.StateEnum.STATE_STILL);
        }
    }
}