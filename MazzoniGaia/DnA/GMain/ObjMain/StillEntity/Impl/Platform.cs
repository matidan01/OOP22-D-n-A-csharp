using DnA.Game.Player.impl;
using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;

namespace DnA.GMain.ObjMain.StillEntity.Impl
{
    /// <summary>
    /// A still platform.
    /// </summary>
    public class Platform : AbstractEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        /// <param name="position">The position of the Platform.</param>
        /// <param name="height">The height of the Platform.</param>
        /// <param name="width">The width of the Platform.</param>
        public Platform(Position2d position, double height, double width)
            : base(position, height, width, IEntity.EntityType.PLATFORM)
        {
        }
    }
}