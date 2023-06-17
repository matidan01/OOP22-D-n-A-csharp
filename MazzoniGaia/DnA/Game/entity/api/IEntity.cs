


namespace DnA.Game.Entity.api{
    public interface IEntity
    {
        /// <summary>
        /// An enumeration that describes the different types of entities.
        /// </summary>
        enum EntityType
        {
            /// <summary>
            /// Represents the player.
            /// </summary>
            PLAYER,
            /// <summary>
            /// Represents the door that the angel can open.
            /// </summary>
            ANGEL_DOOR,
            /// <summary>
            /// Represents the door that the devil can open.
            /// </summary>
            DEVIL_DOOR,
            /// <summary>
            /// Represents the lever.
            /// </summary>
            LEVER,
            /// <summary>
            /// Represents the button.
            /// </summary>
            BUTTON,
            /// <summary>
            /// Represents a puddle that only the angel can walk on.
            /// </summary>
            BLUE_PUDDLE,
            /// <summary>
            /// Represents a puddle that only the devil can walk on.
            /// </summary>
            RED_PUDDLE,
            /// <summary>
            /// Represents a puddle that no character can walk on.
            /// </summary>
            PURPLE_PUDDLE,
            /// <summary>
            /// Represents a platform.
            /// </summary>
            PLATFORM,
            /// <summary>
            /// Represents a platform that can be moved by a button or a lever.
            /// </summary>
            MOVABLEPLATFORM,
            /// <summary>
            /// Represents a diamond.
            /// </summary>
            DIAMOND
        }
    
        /// <summary>
        /// Returns the position of the entity.
        /// </summary>
        /// <returns>The position of the entity. </returns>
        Position2d GetPosition();

        /// <summary>
        /// Sets the position of the entity.
        /// </summary>
        /// <param name="pos">The new position.</param>
        void SetPosition(Position2d pos);

        /// <summary>
        /// Sets the x-axis of the position.
        /// </summary>
        /// <param name="x">The x-axis value.</param>
        void GetPositionX(double x);

        /// <summary>
        /// Sets the x-axis of the position.
        /// </summary>
        /// <param name="y">The y-axis value.</param>
        void SetPositionY(double y);

        /// <summary>
        /// Gets the type fp the entity.
        /// </summary>
        /// <returns>The type of the entity. </returns>
        EntityType GetType();
    
    }

}
