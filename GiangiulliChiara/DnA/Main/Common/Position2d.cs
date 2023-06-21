using System;
namespace DnA.Main.Common
{
    /// <summary>
    /// A class representing a point in a 2-dimensional space.
    /// </summary>
    public class Position2d
    {
        private readonly double _x, _y;

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
    /// Returns the first coordinate of the position.
    /// </summary>
    /// <returns> The first coordinate.</returns>
    public double GetX() => _x;

    /// <summary>
    /// Returns the second coordinate of the position.
    /// </summary>
    /// <returns> The second coordinate.</returns>
    public double GetY() => _y;

    /// Moves the position by adding a 2-dimensional vector.
    /// <param name="vector">the 2-dimensional vector>
    /// <returns>true the new position
    public Position2d Sum(Vector2d vector) => new (_x + vector.GetX(), _y + vector.GetY());

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string ToString() => "Position2d(" + _x + "," + _y + ")";


    /// <summary>
    /// Checks if this position is on the right of the specified position.
    /// </summary>
    /// <param name="p">The position to compare.</param>
    /// <returns>true if this position is on the right, false otherwise.</returns>
    public bool IsOnTheRight(Position2d p) => _x > p.GetX();

    /// <summary>
    /// Checks if this position is above the specified position.
    /// </summary>
    /// <param name="p">The position to compare.</param>
    /// <returns>true if this position is above, false otherwise.</returns>
    public bool IsAbove(Position2d p) => _y < p.GetY();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>    
    public override bool Equals(object? obj) 
    {
        if (obj is not Position2d) {
            return false;
        }
        Position2d pos = (Position2d) obj;
        return Double.Equals(pos.GetX(),_x) && Double.Equals(pos.GetY(), _y);
        
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override int GetHashCode() 
    {
        int prime = 31;
        int result = 1;
        result = prime * result;
        result = prime * result;
        return result;
    }

    }
}