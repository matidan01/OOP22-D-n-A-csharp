using System.Numerics;

namespace DnA {

    /// <summary>
    /// A class representing a 2-dimensional vector that describes
    /// the direction and velocity of a movement.
    /// </summary>
    public class Vector2d
    {
        public double _x { get; private set; }
        public double _y { get; private set; }

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
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string representation of the vector.</returns>
        public override string ToString()
        {
            return $"Vector2d({_x},{_y})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current vector.
        /// </summary>
        /// <param name="obj">The object to compare with the current vector.</param>
        /// <returns>True if the specified object is equal to the current vector; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2d))
            {
                return false;
            }

            Vector2d vec = (Vector2d)obj;
            return vec._x.Equals(_x) && vec._y.Equals(_y);
        }

        /// <summary>
        /// Returns a hash code for the current vector.
        /// </summary>
        /// <returns>A hash code for the current vector.</returns>
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + _x.GetHashCode();
            result = prime * result + _y.GetHashCode();
            return result;
        }

        public static implicit operator Vector2(Vector2d v)
        {
            throw new NotImplementedException();
        }
    }

}