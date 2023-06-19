

using DnA.Game.enitity.StillEntity.api;
using DnA.Game.Entity.MovableEntity.impl;
using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Main.Common;

/// <summary>
/// An ActivableObject that moves its platform when activated by the player.
/// It can be either a Lever or a Button.
/// The Lever moves the {@link MovablePlatform} when it is touched by the player.
/// The Button moves the {@link MovablePlatform} while it is being touched by the player.
/// </summary>
namespace DnA.Game.Entity.StillEntity.impl{
    public class ActivableObjectImpl : AbstractEntity, IActivableObject
    {
        private bool isActive;
        private IPlayer? player;
        private readonly MovablePlatform movablePlatform;
        
        public ActivableObjectImpl(Position2d pos, double height, double width, MovablePlatform movablePlatform, EntityType type)
        : base(pos, height, width, type)
        {
            this.movablePlatform = movablePlatform;
        }

        /// <summary>
        /// Sets the player that has touched the button.
        /// </summary>
        /// <param name="player"></param>
        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the Player that has touched the button.
        /// </summary>
        /// <returns></returns>
        public IPlayer? GetPlayer()
        {
            return player;
        }

        public void ResetPlayer()
        {
            player = null;
        }

        /// <summary>
        /// Resets the player.
        /// </summary>
        /// <returns></returns>
        public MovablePlatform GetMovablePlatform()
        {
            return movablePlatform;
        }

        /// <summary>
        /// Gets the MovablePlatform controlled by the ActivableObject.
        /// </summary>
        public void Activate()
        {
            isActive = true;
            movablePlatform.Move(movablePlatform.GetOriginalPosition(), movablePlatform.GetFinalPosition());
        }

        /// <summary>
        /// A method that moves the MovablePlatform from its starting position towards its final position.
        /// </summary>
        public void Deactivate()
        {
            isActive = false;
            movablePlatform.Move(movablePlatform.GetFinalPosition(), movablePlatform.GetOriginalPosition());
        }

        /// <summary>
        /// A method that moves the MovablePlatform from its final position towards its starting position.
        /// </summary>
        /// <returns></returns>
        public bool IsActivated()
        {
            return isActive;
        }
    }
}