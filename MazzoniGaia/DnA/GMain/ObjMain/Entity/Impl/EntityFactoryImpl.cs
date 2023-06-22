
using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.GMain.ObjMain.MovableEntity.Impl;
using DnA.GMain.ObjMain.StillEntity.Impl;
using DnA.ObjMain.StillEntity.Impl;
using static DnA.GMain.ObjMain.Entity.Api.IEntity;

namespace DnA.ObjMain.Entity.Impl
{
    /// <summary>
    /// A class that implements the <see cref="IEntityFactory"/> interface's createEntity method.
    /// </summary>
    public class EntityFactoryImpl : IEntityFactory
    {
        /// <summary>
        /// A constant for the value of the diamond.
        /// </summary>
        private const double DIAMOND_VALUE = 1;
        private readonly Vector2d defaultVector = new (0, 0);

        /// <inheritdoc/>
        public IEntity CreateEntity(MovablePlatform? movablePlatform, EntityType type, params Position2d[] position)
        {
            return type switch
            {
                EntityType.BUTTON => new ActivableObjectImpl(position[0], IEntityFactory.BUTTON_HEIGHT, IEntityFactory.DEF_WIDTH, movablePlatform, EntityType.BUTTON),
                EntityType.LEVER => new ActivableObjectImpl(position[0], IEntityFactory.DEF_HEIGHT, IEntityFactory.DEF_WIDTH, movablePlatform, EntityType.LEVER),
                EntityType.RED_PUDDLE => new Puddle(position[0], IEntityFactory.PUDDLE_HEIGHT, IEntityFactory.PUDDLE_WIDTH, EntityType.RED_PUDDLE),
                EntityType.BLUE_PUDDLE => new Puddle(position[0], IEntityFactory.PUDDLE_HEIGHT, IEntityFactory.PUDDLE_WIDTH, EntityType.BLUE_PUDDLE),
                EntityType.PURPLE_PUDDLE => new Puddle(position[0], IEntityFactory.PUDDLE_HEIGHT, IEntityFactory.PUDDLE_WIDTH, EntityType.PURPLE_PUDDLE),
                EntityType.ANGEL_DOOR => new Door(position[0], IEntityFactory.DOOR_HEIGHT, IEntityFactory.DOOR_WIDTH, EntityType.ANGEL_DOOR),
                EntityType.DEVIL_DOOR => new Door(position[0], IEntityFactory.DOOR_HEIGHT, IEntityFactory.DOOR_WIDTH, EntityType.DEVIL_DOOR),
                EntityType.PLATFORM => new Platform(position[0], IEntityFactory.DEF_HEIGHT, IEntityFactory.PLATFORM_WIDTH),
                EntityType.MOVABLEPLATFORM => new MovablePlatform(position[0], defaultVector, IEntityFactory.DEF_HEIGHT, IEntityFactory.PLATFORM_WIDTH, EntityType.MOVABLEPLATFORM, position[1]),
                EntityType.DIAMOND => new Main.Extra.Diamond(IEntityFactory.DIAMOND_HEIGHT, IEntityFactory.DIAMOND_WIDTH, DIAMOND_VALUE, position[0]),
                _ => throw new ArgumentException("Not an acceptable argument")
            };
        }
    }
}