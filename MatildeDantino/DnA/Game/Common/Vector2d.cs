namespace DnA {
    public class Vector2d
    {
        public double _x { get; private set; }
        public double _y { get; private set; }

        public Vector2d(double x, double y)
        {
            _x = x;
            _y = y;
        
        }
        public void SumX(double d)
        {
            _x += d;
        }

        public void SumY(double d)
        {
            _y += d;
        }

        public override string ToString()
        {
            return $"Vector2d({_x},{_y})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2d))
            {
                return false;
            }

            Vector2d vec = (Vector2d)obj;
            return vec._x.Equals(_x) && vec._y.Equals(_y);
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