using DnA;

public interface ICommandFactory
{
    ICommand Right();
    ICommand Left();
    ICommand Jump();
    ICommand Stop();
}
