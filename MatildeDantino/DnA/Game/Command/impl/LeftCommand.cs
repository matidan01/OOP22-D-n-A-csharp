namespace DnA {
public class LeftCommand : ICommand
    {
        private readonly IPlayer player;

        public LeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            this.player.SetVectorX(-IPlayer.STANDARDVELOCITY);
            this.player.SetStateY(State.StateEnum.STATE_LEFT);
        }
    }
}