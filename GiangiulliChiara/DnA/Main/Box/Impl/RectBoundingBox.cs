using DnA.Main.Box.Api;
using DnA.Main.Common;
namespace DnA.Main.Box.Impl
{

    /// <summary>
    /// Class that implements the <see cref="IBoundingBox"/> interface with a rectangular shape.
    /// </summary>
    public class RectBoundingBox : IBoundingBox
    {
        private readonly Position2d _position;
        private readonly double _height;
        private readonly double _width;

        public RectBoundingBox(Position2d p, double h, double w) {
            _position = p;
            _height = h;
            _width = w;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public double GetHeight() => _height;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public double GetWidth() => _width;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public Position2d GetPosition() => _position;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public void SetPosition(Position2d pos)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public bool IsCollidingWith(Position2d p, double height, double width)
        {
            return _position.GetX() + _width >= p.GetX()
                && _position.GetX() <= p.GetX() + width
                && _position.GetY() + _height >= p.GetY()
                && _position.GetY() <= p.GetY() + height;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public bool SideCollision(Position2d p, double height, double width)
        {
            return _position.GetY() + _height >= p.GetY()
                && _position.GetY() <= p.GetY() + height
                && (_position.GetX() + _width <= p.GetX() || _position.GetX() >= p.GetX() + width);
        }
    }
}