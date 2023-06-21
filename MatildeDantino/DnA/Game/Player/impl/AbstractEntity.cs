using DnA.Main.Box.Impl;
using DnA.Main.Box.Api;
using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;


namespace DnA.Game.Player.impl
{

    /// <summary>
    /// Abstract class that implements the Entity interface.
    /// </summary>
    public abstract class AbstractEntity : IEntity
    {
        private readonly IBoundingBox _box;
        public IEntity.EntityType _type { get; }

        /// <summary>
        /// Constructs a new AbstractEntity object.
        /// </summary>
        /// <param name="pos">The position of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        /// <param name="width">The width of the entity.</param>
        /// <param name="type">The entity type.</param>
        public AbstractEntity(Position2d pos, double height, double width, IEntity.EntityType type)
        {
            _box = new RectBoundingBox(pos, height, width);
            _type = type;
        }

        /// <inheritdoc/>
        public Position2d GetPosition() => _box.GetPosition();

        /// <inheritdoc/>
        public void SetPosition(Position2d pos) => _box.SetPosition(pos);

        /// <inheritdoc/>
        public IBoundingBox GetBoundingBox() => new RectBoundingBox(_box.GetPosition(), _box.GetHeight(), _box.GetWidth());

        /// <inheritdoc/>
        public void SetPositionX(double x) => this.SetPosition(new Position2d(x, this.GetPosition().GetY()));

        /// <inheritdoc/>
        public void SetPositionY(double y) => this.SetPosition(new Position2d(this.GetPosition().GetX(), y));

        IEntity.EntityType IEntity.GetType() => _type;

    }

}