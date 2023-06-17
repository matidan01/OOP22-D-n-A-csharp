<<<<<<< HEAD
using System.Numerics;
using DnA;
using DnA.Game.enitity.Api;
using DnA.Game.Entity.api;


=======
using DnA.Game.Common;
<<<<<<< HEAD

=======
>>>>>>> 1b40072c499f8f2f1c4693cb2651021a7f37b622
>>>>>>> 1462660f3b055914a632e8bc28843d2a8b8d7d55
/// <summary>
/// Abstract class that implements the <see cref="MovableEntity"/> interface.
/// </summary>
namespace DnA
{
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

<<<<<<< HEAD
    protected AbstractMovableEntity(Position2d pos, Vector2d vet, double height, double width, IEntity.EntityType type)
    {
        this.pos = pos;
        this.vet = vet;
        this.height = height;
        this.width = width;
        this.type = type;
    }


=======
    public void SetVector(double x, double y) {
        _vector = new Vector2d(x,y);
    }

>>>>>>> 1b40072c499f8f2f1c4693cb2651021a7f37b622
    /// <inheritdoc/>
    public void SetVectorX(double x)
    {
        _vector = new Vector2d(x, _vector.GetY());
    }

    /// <inheritdoc/>
    public void SetVectorY(double y)
    {
        _vector = new Vector2d(_vector.GetX(), y);
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
    
}
