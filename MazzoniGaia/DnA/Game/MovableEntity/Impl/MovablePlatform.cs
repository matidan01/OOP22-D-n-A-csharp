
using DnA.Game.enitity.Api;

namespace DnA.Game.enitity.MovableEntity.impl{
    public class MovablePlatform : AbstractMovableEntity 
    {
        private Position2d originalPosition { get; set; }
        private Position2d finalPosition { get; set; }
        private Position2d lastPostition { get; set; }
        private Vector2d previousVector { get; set; }

        public MovablePlatform(Position2d position, Vector2d vector, double height, double width, Position2d finalPosition)
            : base(position, vector, height, width, IEntity.EntityType.MOVABLEPLATFORM);
        {
            _originalPosition = position;
            _finalPosition = finalPosition;
            _lastPosition = lastPosition;
            _previousVector = new Vector2d(0, 0);
        }

        /// <summary>
        /// A method that finds the direction in which the platform needs to move, 
        /// and sets the vector accordingly.
        /// </summary>
        /// <param name="position1"> The stating position of the platform </param>
        /// <param name="position2"> The position the platform wants to reach </param>
        public void findVector(Position2d position1, Position2d position2)
        {
            double x = 0.0;
            double y = 0.0;
            if (position1._x != position2._x)
            {
                x = position2.IsOnTheRight(position1) ? +0.5 : -0.5;
            }
            if (position1._y != position2._y)
            {
                y = position2.IsAbove(position1) ? -0.5 : +0.5; 
            }
            this.setVector(new Vector2d(x, y));
        }
        /// <summary>
        /// A method that allows the platform to move from a starting point to a final point.
        /// </summary>
        /// <param name="Position2d"> the starting position of the platform </param>
        /// <param name="Position2d"> the final position that the platform wants to reach </param>
        public void Move(Position2d position1, Position2d position2)
        {
            _previousVector = _.getVector();
            findVector(position1, position2);
        }

        /// <summary>
        /// Checks wheter the platform position is between itrs original position and its final position.
        /// </summary>
        /// <returns> false if the platform has gone out of range. </returns>
        public boolean IsBetweenRange()
        {
            double maxX = Math.Max(_originalPosition._x , _finalPosition._x);
            double minX =  Math.Min(_originalPosition._x, _finalPosition._x);
            double maxY = Math.Max(_originalPosition._y, _finalPosition._y);
            double minY = Math.Min(_originalPosition._y, _finalPosition._y);
        }

        /// <summary>
        /// Checks whether the platform has gone out of range, and if it did, 
        /// sets its position to its last position. 
        /// </summary>
        public void findLimit()
        {
            if (!IsBetweenRange())
            {
                _.SetPosition(_lastPosition);
                _.SetVector(new Vector2d(0, 0));
            }
        }

        public void MovablePlatformUpdate()
        {
            _SetLastPosition();
            _Update();
            _FindLimit();
        }


    }
}