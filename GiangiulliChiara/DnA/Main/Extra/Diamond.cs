using DnA.Game.Player.impl;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.Main.Common;

namespace DnA.Main.Extra
{
    /// <summary>
    /// Entity that allows to increase the game score.
    /// </summary>
    public class Diamond : AbstractEntity
    {
        private readonly double value;

        /// <summary>
        /// Diamond constructor.
        /// </summary>
        /// <param name="h">The height of the diamond.</param>
        /// <param name="w">The width of the diamond.</param>
        /// <param name="v">The value of the diamond.</param>
        /// <param name="p">The position of the diamond.</param>
        public Diamond(double h, double w, double v, Position2d p): base(p, h, w, IEntity.EntityType.DIAMOND)
        {
            this.value = v;
        }

        /// <summary>
        /// Gets the value of the diamond.
        /// </summary>
        /// <returns>The value of the diamond.</returns>
        public double GetValue()
        {
            return this.value;
        }
    }

}