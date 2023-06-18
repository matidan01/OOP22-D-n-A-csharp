using DnA.Main.Box.Api;
using DnA.Main.Common;
namespace DnA.Main.Extra
{
    public class Entity
    {
        internal IBoundingBox GetBoundingBox()
        {
            throw new NotImplementedException();
        }

        internal Position2d GetPosition()
        {
            throw new NotImplementedException();
        }

        internal EntityType Type()
        {
            throw new NotImplementedException();
        }

        public enum EntityType
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

    }

}