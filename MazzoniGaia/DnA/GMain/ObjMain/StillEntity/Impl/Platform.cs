using DnA.Game.Player.impl;
using DnA.Main.Common;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.Entity.Api;

namespace OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl
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