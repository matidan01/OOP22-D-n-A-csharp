namespace Movement;

using DnA.Game.Common;
using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Game.Command.api;
using DnA.Game.Command.impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class MovementTest
    {
        private static readonly Position2d START_POSITION = new Position2d(0, 0);
        private static readonly Vector2d START_VECTOR = new Vector2d(1, 0);
        private const double HEIGHT = 10.0;
        private const double WIDTH = 10.0;
        private const IPlayer.PlayerType TYPE = IPlayer.PlayerType.ANGEL;
        private readonly Player _player = new Player(START_POSITION, START_VECTOR, HEIGHT, WIDTH, TYPE);

        [TestMethod]
        public void TestPlayerUpdate()
        {   
            ICommandFactory _command = new CommandFactory(_player);
            Position2d expectedPosition = new Position2d(0, 0).Sum(START_VECTOR);
            _player.Update();
            Assert.AreEqual(expectedPosition, _player.GetPosition());
        }

        [TestMethod]
        public void TestCommand()
        {
            // Test the "right" command
            ICommandFactory _command = new CommandFactory(_player);
            Vector2d expectedVectorRight = new Vector2d(IPlayer.STANDARDVELOCITY, 0);
            var expectedStateRight = Tuple.Create(State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
            _command.Right().Execute();
            Assert.AreEqual(expectedVectorRight, _player.GetVector());
            Assert.AreEqual(expectedStateRight, _player.GetStateCopy().GetPairState());

            // Test the "left" command
            Vector2d expectedVectorLeft = new Vector2d(-IPlayer.STANDARDVELOCITY, 0);
            var expectedStateLeft = Tuple.Create(State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
            _command.Left().Execute();
            Assert.AreEqual(expectedVectorLeft, _player.GetVector());
            Assert.AreEqual(expectedStateLeft, _player.GetStateCopy().GetPairState());

            // Test the "jump" command
            Vector2d expectedVectorJump = new Vector2d(0, -IPlayer.JUMPVELOCITY);
            var expectedStateJump = Tuple.Create(State.StateEnum.STATE_STANDING, State.StateEnum.STATE_RIGHT);
            _command.Stop().Execute();
            _command.Jump().Execute();
            Assert.AreEqual(expectedVectorJump, _player.GetVector());
            Assert.AreEqual(expectedStateJump, _player.GetStateCopy().GetPairState());
        }
    }
