

using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.Game.Player.impl;
using DnA.Game.Player.api;

namespace DnA.ObjMain.StillEntity.Impl
{
    /// <summary>
    /// A door that can be opened only by the corresponding player.
    /// </summary>
    public class Door : AbstractEntity
    {
        /// <summary>
        /// An enumeration that describes two states the door can be in.
        /// </summary>
        public enum DoorState
        {
            /// <summary>
            /// Describes that the door is open.
            /// </summary>
            OPEN_DOOR,

            /// <summary>
            /// Describes that the door is closed.
            /// </summary>
            CLOSED_DOOR
        }

        private DoorState _state;
        private IPlayer? _player = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class.
        /// </summary>
        /// <param name="position">The position of the Door.</param>
        /// <param name="height">The height of the Door.</param>
        /// <param name="width">The width of the Door.</param>
        /// <param name="type">The type of the Door (Angel door, Devil door).</param>
        public Door(Position2d position, double height, double width, IEntity.EntityType type)
            : base(position, height, width, type)
        {
            _state = DoorState.CLOSED_DOOR;
        }

        /// <summary>
        /// Gets the state of the door (open, closed).
        /// </summary>
        /// <returns>The state of the door.</returns>
        public DoorState GetDoorState()
        {
            return _state;
        }

        /// <summary>
        /// A method that opens the door if the correct player is standing in front of it.
        /// The door can't be closed after it has been opened.
        /// </summary>
        /// <param name="player">The player standing in front of the door.</param>
        public void OpenDoor(IPlayer player)
        {
            if (_state == DoorState.CLOSED_DOOR)
            {
                switch (player.GetPlayerType())
                {
                    case IPlayer.PlayerType.ANGEL:
                        {
                            if (_type.Equals(IEntity.EntityType.ANGEL_DOOR))
                            {
                                _state = DoorState.OPEN_DOOR;
                                _player = player;
                            }
                            break;
                        }
                    case IPlayer.PlayerType.DEVIL:
                        {
                            if (_type.Equals(IEntity.EntityType.DEVIL_DOOR))
                            {
                                _state = DoorState.OPEN_DOOR;
                                _player = player;
                            }
                            break;
                        }
                    default:
                        throw new ArgumentException("Not an acceptable argument");
                }
            }
        }

        /// <summary>
        /// Gets the player that is opening the door.
        /// </summary>
        /// <returns>The player opening the door.</returns>
        public IPlayer? GetPlayer()
        {
            return _player;
        }

        /// <summary>
        /// Empties the player.
        /// </summary>
        public void ResetPlayer()
        {
            _player = null;
        }

        /// <summary>
        /// Closes the door.
        /// </summary>
        public void CloseDoor()
        {
            _state = DoorState.CLOSED_DOOR;
        }
    }
}