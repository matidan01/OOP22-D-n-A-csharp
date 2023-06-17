using DnA.Game.Player.api;
using DnA.Game.Command.api;
using DnA.Game.Player.impl;

namespace DnA.Game.Command.impl {

    /// <summary>
    /// ICommandFactory implementation.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        private readonly IPlayer _player;

        ///
        /// Creates a new CommandFactoryImpl instance with the specified player.
        ///
        /// <param name="player">The player.</param>
        ///
        public CommandFactory(IPlayer player)
        {
            _player = player;
        }

        /// <inheritdoc />
        public ICommand Right()
            {
                return new RightCommand(_player);
            }

        /// <inheritdoc />
        public ICommand Left()
        {
            return new LeftCommand(_player);
        }

        /// <inheritdoc />
        public ICommand Jump()
        {
            return new JumpCommand(_player);
        }

        /// <inheritdoc />
        public ICommand Stop()
        {
            return new StopCommand(_player);
        }

        public class JumpCommand : ICommand
        {
            private readonly IPlayer _player;

            public JumpCommand(IPlayer player)
            {
                _player = player;
            }

            public void Execute()
            {
                if (_player.GetStateCopy()._stateX != State.StateEnum.STATE_JUMPING)
                {
                    _player.SetVectorY(-IPlayer.JUMPVELOCITY);
                    _player.SetStateX(State.StateEnum.STATE_JUMPING);
                }
            }
        }

        public class LeftCommand : ICommand
        {   
            private readonly IPlayer _player;

            public LeftCommand(IPlayer player)
            {
                _player = player;
            }

            public void Execute()
            {
                _player.SetVectorX(-IPlayer.STANDARDVELOCITY);
                _player.SetStateY(State.StateEnum.STATE_LEFT);
            }
        }

        public class RightCommand : ICommand
        {
            private readonly IPlayer _player;

            public RightCommand(IPlayer player)
            {
                _player = player;
            }

            public void Execute()
            {
                _player.SetVectorX(IPlayer.STANDARDVELOCITY);
                _player.SetStateY(State.StateEnum.STATE_RIGHT);
            }
        }

        public class StopCommand : ICommand
        {
            private readonly IPlayer _player;

            public StopCommand(IPlayer player)
            {
                _player = player;
            }

            public void Execute()
            {
                _player.SetVectorX(0);
                _player.SetStateY(State.StateEnum.STATE_STILL);
            }
        }

    }
}
