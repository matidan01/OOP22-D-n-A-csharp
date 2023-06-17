namespace DnA {
    using System;
    using DnA.Game.Common;

    /// <summary>
    /// A class representing a point in a 2-dimensional space.
    /// </summary>
    public class Position2d
    {
        public double _x { get; }
        public double _y { get; }

        /// <summary>
        /// Constructs a new Position2d object with the specified coordinates.
        /// </summary>
        /// <param name="x">The first coordinate of the position.</param>
        /// <param name="y">The second coordinate of the position.</param>
        public Position2d(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Moves the position by adding a 2-dimensional vector.
        /// </summary>
        /// <param name="vector">The 2-dimensional vector.</param>
        /// <returns>The new position.</returns>
        public Position2d Sum(Vector2d vector)
        {
            return new Position2d(_x + vector._x, _y + vector._y);
        }

        /// <summary>
        /// Returns a string representation of the position.
        /// </summary>
        /// <returns>A string representation of the position.</returns>
        public override string ToString()
        {
            return $"Position2d({_x},{_y})";
        }

        /// <summary>
        /// Checks if this position is on the right of the specified position.
        /// </summary>
        /// <param name="p">The position to compare.</param>
        /// <returns><c>true</c> if this position is on the right, <c>false</c> otherwise.</returns>
        public bool IsOnTheRight(Position2d p)
        {
            return _x > p._x;
        }

        /// <summary>
        /// Checks if this position is above the specified position.
        /// </summary>
        /// <param name="p">The position to compare.</param>
        /// <returns><c>true</c> if this position is above, <c>false</c> otherwise.</returns>
        public bool IsAbove(Position2d p)
        {
            return _y < p._y;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current position.
        /// </summary>
        /// <param name="obj">The object to compare with the current position.</param>
        /// <returns>True if the specified object is equal to the current position; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Position2d))
            {
                return false;
            }

            Position2d pos = (Position2d)obj;
            return pos._x.Equals(_x) && pos._y.Equals(_y);
        }

        /// <summary>
        /// Returns a hash code for the current position.
        /// </summary>
        /// <returns>A hash code for the current position.</returns>
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + _x.GetHashCode();
            result = prime * result + _y.GetHashCode();
            return result;
        }
    }

}