

using DnA.Game.Entity.api;
using DnA.Main.Common;

namespace DnA.Game.MovableEntity.Api{
    public interface IMovableEntity : IEntity
    {
        Vector2d GetVector();

        void SetVector(Vector2d vector);

        void SetVectorY(double y);

        void SetVectorX(double x);

        void ResetY();

        void ResetX();

        void Update();

    }
}