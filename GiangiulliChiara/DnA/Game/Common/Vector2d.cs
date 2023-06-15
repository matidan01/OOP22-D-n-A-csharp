using System;

namespace DnA.Game.Common{
    /// <summary>
    /// A class representing a vector in 2-dimensional space that describes
    /// the direction and velocity of a movement.
    /// </summary>
    public class Vector2d
    {
        private double _x, _y;

        /// <summary>
        /// Constructs a new Vector2d object with the specified coordinates.
        /// </summary>
        /// <param name="x">The first coordinate of the vector.</param>
        /// <param name="y">The second coordinate of the vector.</param>
        public Vector2d(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns the first coordinate of the vector.
        /// </summary>
        /// <returns>The first coordinate.</returns>
        public double GetX() => _x;

        /// <summary>
        /// Returns the second coordinate of the vector.
        /// </summary>
        /// <returns>The second coordinate.</returns>
        public double GetY() => _y;

        /// <summary>
        /// Changes the first coordinate of the vector by adding a double number.
        /// </summary>
        /// <param name="d">The double number to be added.</param>
        public void SumX(double d)
        {
            _x += d;
        }

        /// <summary>
        /// Changes the second coordinate of the vector by adding a double number.
        /// </summary>
        /// <param name="d">The double number to be added.</param>
        public void SumY(double d)
        {
            _y += d;
        }

        /// <summary>
        /// Returns a string representation of the Vector2d object.
        /// </summary>
        /// <returns>A string representation of the Vector2d object.</returns>
        public override string ToString() => "Vector2d(" + _x + "," + _y + ")";

        /// <summary>
        /// Determines whether the specified object is equal to the current Vector2d object.
        /// </summary>
        /// <param name="obj">The object to compare with the current Vector2d object.</param>
        /// <returns>true if the specified object is equal to the current Vector2d object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2d))
            {
                return false;
            }
            Vector2d vec = (Vector2d)obj;
            return Double.Equals(vec._x, _x) && Double.Equals(vec._y, _y);
        }

        /// <summary>
        /// Returns a hash code for the current Vector2d object.
        /// </summary>
        /// <returns>A hash code for the current Vector2d object.</returns>
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
