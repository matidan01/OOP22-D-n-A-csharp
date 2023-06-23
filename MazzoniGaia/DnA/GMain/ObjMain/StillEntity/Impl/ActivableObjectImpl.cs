using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Main.Common;
using DnA.GMain.ObjMain.MovableEntity.Impl;
using DnA.GMain.ObjMain.StillEntity.Api;
using static DnA.GMain.ObjMain.Entity.Api.IEntity;

namespace DnA.GMain.ObjMain.StillEntity.Impl
{

    /// <summary>
    /// An ActivableObject that moves its platform when activated by the player.
    /// It can be either a Lever or a Button.
    /// The Lever moves the movableplatform when it is touched by the player.
    /// The Button moves the movableplatform while it is being touched by the player.
    /// </summary>


    public class ActivableObjectImpl : AbstractEntity, IActivableObject
    {
        private bool _isActive;
        private IPlayer? _player;
        private readonly MovablePlatform? _movablePlatform;

        public ActivableObjectImpl(Position2d pos, double height, double width, MovablePlatform? movablePlatform, EntityType type)
        : base(pos, height, width, type)
        {
            _movablePlatform = movablePlatform;
        }

        /// <summary>
        /// Sets the player that has touched the button.
        /// </summary>
        /// <param name="player"></param>
        public void SetPlayer(IPlayer player)
        {
            _player = player;
        }

        /// <summary>
        /// Gets the Player that has touched the button.
        /// </summary>
        /// <returns> the player</returns>
        public IPlayer? GetPlayer()
        {
            return _player;
        }

        /// <summary>
        /// Resets the player.
        /// </summary>
        public void ResetPlayer()
        {
            _player = null;
        }

        /// <summary>
        /// Gets the MovablePlatform controlled by the ActivableObject.
        /// </summary>
        public MovablePlatform? GetMovablePlatform()
        {
            return _movablePlatform;
        }

        /// <summary>
        /// A method that moves the MovablePlatform from its starting position towards its final position.
        /// </summary>
        public void Activate()
        {
            _isActive = true;
            _movablePlatform?.Move(_movablePlatform.GetOriginalPosition(), _movablePlatform.GetFinalPosition());
        }

        /// <summary>
        /// A method that moves the MovablePlatform from its final position towards its starting position.
        /// </summary>
        public void Deactivate()
        {
            _isActive = false;
            _movablePlatform?.Move(_movablePlatform.GetFinalPosition(), _movablePlatform.GetOriginalPosition());
        }

        /// <summary>
        /// A method that tells whether the ActivableObject is activated.
        /// </summary>
        /// <returns> whether the ActivableObject is activated. </returns>
        public bool IsActivated()
        {
            return _isActive;
        }
    }
}