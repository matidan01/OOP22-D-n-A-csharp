using System.Numerics;
using DnA;
using DnA.Game.enitity.Api;
using DnA.Game.Entity.api;


/// <summary>
/// Abstract class that implements the <see cref="MovableEntity"/> interface.
/// </summary>
public abstract class AbstractMovableEntity : AbstractEntity, MovableEntity
{
    private Position2d pos;
    private Vector2d vet;
    private double height;
    private double width;
    private IEntity.EntityType type;


    private Vector2d _vector { get; set; }

    /// <summary>
    /// Constructs a new <see cref="AbstractMovableEntity"/> object.
    /// </summary>
    /// <param name="pos">The position of the entity.</param>
    /// <param name="vet">The start vector of the entity.</param>
    /// <param name="height">The height of the entity.</param>
    /// <param name="width">The width of the entity.</param>
    /// <param name="type">The type of the entity.</param>
    public AbstractMovableEntity(Position2d pos, Vector2d vet, double height, double width, IEntity.EntityType type)
        : base(pos, height, width, type)
    {
        _vector = vet;
    }

    protected AbstractMovableEntity(Position2d pos, Vector2d vet, double height, double width, IEntity.EntityType type)
    {
        this.pos = pos;
        this.vet = vet;
        this.height = height;
        this.width = width;
        this.type = type;
    }


    /// <inheritdoc/>
    public void SetVectorX(double x)
    {
        _vector = new Vector2d(x, _vector.Y);
    }

    /// <inheritdoc/>
    public void SetVectorY(double y)
    {
        _vector = new Vector2d(_vector.X, y);
    }

    /// <inheritdoc/>
    public void ResetX()
    {
        this.SetVectorX(0);
    }

    /// <inheritdoc/>
    public void ResetY()
    {
        this.SetVectorY(0);
    }

    /// <inheritdoc/>
    public void Update()
    {
        this.SetPosition(this.GetPosition().Sum(_vector));
    }
}
