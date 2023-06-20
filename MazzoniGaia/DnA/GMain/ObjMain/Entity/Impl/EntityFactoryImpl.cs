using DnA.Game.Entity.api;
using DnA.Game.Entity.MovableEntity.impl;
using DnA.Game.Entity.StillEntity.impl;
using DnA.Main.Common;
using OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.StillEntity.Impl;
using static DnA.Game.Entity.api.IEntity;

namespace OOP22_D_n_A_csharp.MazzoniGaia.DnA.ObjMain.Entity.Impl
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
        private readonly Vector2d defaultVector = new Vector2d(0, 0);

        /// <inheritdoc/>
        public IEntity CreateEntity(MovablePlatform? movablePlatform, EntityType type, params Position2d[] position)
        {
            return type switch
            {
                EntityType.BUTTON => new ActivableObjectImpl(position[0], (double)BUTTON_HEIGHT, (double)DEF_WIDTH, movablePlatform, EntityType.BUTTON),
                EntityType.LEVER => new ActivableObjectImpl(position[0], (double)DEF_HEIGHT, (double)DEF_WIDTH, movablePlatform, EntityType.LEVER),
                EntityType.RED_PUDDLE => new Puddle(position[0], (double)PUDDLE_HEIGHT, (double)PUDDLE_WIDTH, EntityType.RED_PUDDLE),
                EntityType.BLUE_PUDDLE => new Puddle(position[0], (double)PUDDLE_HEIGHT, (double)PUDDLE_WIDTH, EntityType.BLUE_PUDDLE),
                EntityType.PURPLE_PUDDLE => new Puddle(position[0], (double)PUDDLE_HEIGHT, (double)PUDDLE_WIDTH, EntityType.PURPLE_PUDDLE),
                EntityType.ANGEL_DOOR => new Door(position[0], (double)DOOR_HEIGHT, (double)DOOR_WIDTH, EntityType.ANGEL_DOOR),
                EntityType.DEVIL_DOOR => new Door(position[0], (double)DOOR_HEIGHT, (double)DOOR_WIDTH, EntityType.DEVIL_DOOR),
                EntityType.PLATFORM => new Platform(position[0], (double)DEF_HEIGHT, (double)PLATFORM_WIDTH),
                EntityType.MOVABLEPLATFORM => new MovablePlatform(position[0], defaultVector, (double)DEF_HEIGHT, (double)PLATFORM_WIDTH, position[1]),
                EntityType.DIAMOND => new DnA.Main.Extra.Diamond((double)DIAMOND_HEIGHT, (double)DIAMOND_WIDTH, DIAMOND_VALUE, position[0]),
                _ => throw new ArgumentException()
            };
        }
    }
}