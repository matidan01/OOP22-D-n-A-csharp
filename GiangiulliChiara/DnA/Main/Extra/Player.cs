using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.Main.Box.Api;
using DnA.Main.Common;
namespace DnA.Main.Extra
{
    public class Player
    {
        public static double STANDARDVELOCITY = 0.64;

        public Player(Position2d pos, Vector2d vector2d, double height, double width, IPlayer.PlayerType type)
        {
            
        }

        internal IBoundingBox GetBoundingBox()
        {
            throw new NotImplementedException();
        }

        internal Position2d GetPosition()
        {
            throw new NotImplementedException();
        }

        internal State GetStateCopy()
        {
            throw new NotImplementedException();
        }

        internal Vector2d GetVector()
        {
            throw new NotImplementedException();
        }

        internal void ResetX()
        {
            throw new NotImplementedException();
        }

        internal void ResetY()
        {
            throw new NotImplementedException();
        }

        internal void SetPosition(Position2d position2d)
        {
            throw new NotImplementedException();
        }

        internal void SetPositionY(double v)
        {
            throw new NotImplementedException();
        }

        internal void SetStateX(object sTATE_STANDING)
        {
            throw new NotImplementedException();
        }

        internal void SetVectorX(object x)
        {
            throw new NotImplementedException();
        }

        internal void SetVectorY(object value)
        {
            throw new NotImplementedException();
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}