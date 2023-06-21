using DnA.Main.Common;
using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Game.Command.api;
using DnA.Game.Command.impl;
using NUnit.Framework;

namespace DnATest;

[TestFixture]
public class MovementTest
{
    private static readonly Position2d START_POSITION = new(0, 0);
    private static readonly Vector2d START_VECTOR = new(1, 0);
    private const double HEIGHT = 10.0;
    private const double WIDTH = 10.0;
    private const IPlayer.PlayerType TYPE = IPlayer.PlayerType.ANGEL;
    private readonly Player _player = new(START_POSITION, START_VECTOR, HEIGHT, WIDTH, TYPE);

    [Test]
    public void TestPlayerUpdate()
    {   
        Position2d expectedPosition = new Position2d(0, 0).Sum(START_VECTOR);
        _player.Update();
        Assert.AreEqual(expectedPosition, _player.GetPosition());
    }

    [Test]
    public void TestCommand()
    {
        // Test the "right" command
        ICommandFactory _command = new CommandFactory(_player);
        Vector2d expectedVectorRight = new Vector2d(IPlayer.STANDARDVELOCITY, 0);
        (State.StateEnum, State.StateEnum) expectedStateRight = (State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
        _command.Right().Execute();
        Assert.AreEqual(expectedVectorRight, _player.GetVector());
        Assert.AreEqual(expectedStateRight, _player.GetStateCopy().GetPairState());

        // Test the "left" command
        Vector2d expectedVectorLeft = new Vector2d(-IPlayer.STANDARDVELOCITY, 0);
        (State.StateEnum, State.StateEnum) expectedStateLeft = (State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
        _command.Left().Execute();
        Assert.AreEqual(expectedVectorLeft, _player.GetVector());
        Assert.AreEqual(expectedStateLeft, _player.GetStateCopy().GetPairState());

        // Test the "jump" command
        Vector2d expectedVectorJump = new Vector2d(0, -IPlayer.JUMPVELOCITY);
        (State.StateEnum, State.StateEnum) expectedStateJump = (State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
        _command.Stop().Execute();
        _command.Jump().Execute();
        Assert.AreEqual(expectedVectorJump, _player.GetVector());
        Assert.AreEqual(expectedStateJump, _player.GetStateCopy().GetPairState());
    }
}