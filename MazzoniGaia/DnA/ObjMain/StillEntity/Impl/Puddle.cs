using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Main.Common;
using static DnA.Game.Entity.api.IEntity;

namespace OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl
{
    /// <summary>
    /// A puddle with the following characteristics:
    /// - PURPLE: kills both the Angel and the Devil if they fall in it.
    /// - BLUE: kills the Devil if it falls in it. Does nothing to the Angel.
    /// - RED: kills the Angel if it falls in it. Does nothing to the Devil.
    /// </summary>
    public class Puddle : AbstractEntity
    {
        /// <summary>
        /// Constructs a Puddle object.
        /// </summary>
        /// <param name="position">The position of the puddle.</param>
        /// <param name="height">The height of the puddle.</param>
        /// <param name="width">The width of the puddle.</param>
        /// <param name="type">The type of the puddle (PURPLE, BLUE, RED).</param>
        public Puddle(Position2d position, double height, double width, EntityType type) : base(position, height, width, type)
        {
        }

        /// <summary>
        /// Checks whether there should be a game over.
        /// </summary>
        /// <param name="character">The Player touching the puddle.</param>
        /// <returns>True if there should be a game over, otherwise returns False.</returns>
        public bool KillPlayer(Player character)
        {
            switch (_type)
            {
                case EntityType.PURPLE_PUDDLE:
                    return true;
                case EntityType.BLUE_PUDDLE:
                    if (character._type.Equals(IPlayer.PlayerType.DEVIL))
                        return true;
                    break;
                case EntityType.RED_PUDDLE:
                    if (character._type.Equals(IPlayer.PlayerType.ANGEL))
                        return true;
                    break;
                default:
                    throw new ArgumentException();
            }
            return false;
        }
    }
}