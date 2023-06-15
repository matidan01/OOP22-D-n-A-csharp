namespace DnA {
    using System;
    using DnA.Game.Common;

    public class Position2d
{
    public double _x { get; }
    public double _y { get; }

    public Position2d(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public Position2d Sum(Vector2d vector)
    {
        return new Position2d(_x + vector._x, _y + vector._y);
    }

    public override string ToString()
    {
        return $"Position2d({_x},{_y})";
    }

    public bool IsOnTheRight(Position2d p)
    {
        return _x > p._x;
    }

    public bool IsAbove(Position2d p)
    {
        return _y < p._y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Position2d))
        {
            return false;
        }

        Position2d pos = (Position2d)obj;
        return pos._x.Equals(_x) && pos._y.Equals(_y);
    }

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