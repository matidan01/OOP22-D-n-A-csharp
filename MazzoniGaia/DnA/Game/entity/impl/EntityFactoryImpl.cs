

using DnA.Game.enitity.Api;

namespace DnA.Game.enitity.impl{
    public class EntityFactory : IEntityFactory
    {
        /// <summary>
        /// A constant for the value of the diamond.
        /// </summary>
        private const double DIAMOND_VALUE = 1;
        private readonly Vector2d defaultVector = new Vector2d(0, 0);

        public IEntity CreateEntity(MovablePlatform? movablePlatform, IEntity.EntityType type, params Position2d[] position)
        {
            return type switch
            {
                IEntity.EntityType.BUTTON =>
                    new 
            }
        }
    }
}