using DnA;

public class CommandFactory : ICommandFactory
{
    private readonly IPlayer _player;

    public CommandFactory(IPlayer player)
    {
        _player = player;
    }

    public ICommand Right()
        {
            return new RightCommand(_player);
        }

    public ICommand Left()
    {
        return new LeftCommand(_player);
    }

    public ICommand Jump()
    {
        return new JumpCommand(_player);
    }

    public ICommand Stop()
    {
        return new StopCommand(_player);
    }

}
