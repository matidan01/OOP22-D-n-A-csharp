using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.GMain.ObjMain.MovableEntity.Api;



/// <summary>
/// Abstract class that implements the <see cref="MovableEntity"/> interface.
/// </summary>
namespace DnA.Game.Player.impl
{
    public abstract class AbstractMovableEntity : AbstractEntity, IMovableEntity
    {
            private Vector2d _vector;

            /// <summary>
            /// Constructs a new <see cref="AbstractMovableEntity"/> object.
            /// </summary>
            /// <param name="pos">The position of the entity.</param>
            /// <param name="vet">The start vector of the entity.</param>
            /// <param name="height">The height of the entity.</param>
            /// <param name="width">The width of the entity.</param>
            /// <param name="type">The type of the entity.</param>
            public AbstractMovableEntity(Position2d pos,
                                        Vector2d vet,
                                        double height,
                                        double width,
                                        IEntity.EntityType type)
                : base(pos, height, width, type)
            {
                _vector = vet;
            }

            /// <inheritdoc/>
            public void SetVector(Vector2d vec) {
                _vector = vec;
            }

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
            public void Update() => this.SetPosition(this.GetPosition().Sum(_vector));
                
            /// <inheritdoc/>
            public Vector2d GetVector() => _vector;

        }
}
