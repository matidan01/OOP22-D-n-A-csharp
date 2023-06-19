

using DnA.Game.Entity.api;
using DnA.Game.Player.impl;
using DnA.Main.Common;

namespace DnA.Game.Entity.MovableEntity.impl{
    public class MovablePlatform : AbstractMovableEntity 
    {
        private Position2d originalPosition;
        private Position2d finalPosition;
        private Position2d lastPosition;
        private Vector2d previousVector;
        public MovablePlatform(Position2d position, Vector2d vector, double height, double width, IEntity.EntityType type, Position2d fPosition) : base(position, vector, height, width, type)
        {
            originalPosition = position;
            finalPosition = fPosition;
            lastPosition = position;
            previousVector = new(0, 0);
        }

        public void SetLastPosition()
        {
            lastPosition = GetPosition();
        }

        /// <summary>
        /// A method that finds the direction in which the platform needs to move, 
        /// and sets the vector accordingly.
        /// </summary>
        /// <param name="position1"> The stating position of the platform </param>
        /// <param name="position2"> The position the platform wants to reach </param>
        public void FindVector(Position2d position1, Position2d position2)
        {
            double x = 0.0;
            double y = 0.0;
            if (position1.GetX != position2.GetX)
            {
                x = position2.IsOnTheRight(position1) ? +0.5 : -0.5;
            }
            if (position1.GetY != position2.GetY)
            {
                y = position2.IsAbove(position1) ? -0.5 : +0.5; 
            }
            
        }
        /// <summary>
        /// A method that allows the platform to move from a starting point to a final point.
        /// </summary>
        /// <param name="Position2d"> the starting position of the platform </param>
        /// <param name="Position2d"> the final position that the platform wants to reach </param>
        public void Move(Position2d position1, Position2d position2)
        {
            previousVector = GetVector();
            FindVector(position1, position2);
        }

        /// <summary>
        /// Checks wheter the platform position is between itrs original position and its final position.
        /// </summary>
        /// <returns> false if the platform has gone out of range. </returns>
        public bool IsBetweenRange()
        {
            double maxX = Math.Max(originalPosition.GetX() , finalPosition.GetX());
            double minX =  Math.Min(originalPosition.GetX(), finalPosition.GetX());
            double maxY = Math.Max(originalPosition.GetY(), finalPosition.GetY());
            double minY = Math.Min(originalPosition.GetY(), finalPosition.GetY());
            return GetPosition().GetX() >= minX && GetPosition().GetX() <= maxX 
            && GetPosition().GetY() <= maxY && GetPosition().GetY() >= minY;
        }

        /// <summary>
        /// Checks whether the platform has gone out of range, and if it did, 
        /// sets its position to its last position. 
        /// </summary>
        public void FindLimit()
        {
            if (!IsBetweenRange())
            {
                SetPosition(lastPosition);
                SetVector(new Vector2d(0, 0));
            }
        }
        /// <summary>
        /// Updates the position of the movablePlatform.
        /// </summary>
        public void MovablePlatformUpdate()
        {
            SetLastPosition();
            Update();
            FindLimit();
        }


    }
}