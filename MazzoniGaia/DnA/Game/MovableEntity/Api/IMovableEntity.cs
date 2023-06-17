

using DnA.Game.enitity.Api;

namespace DnA.Game.enitity.MovableEntity.Api{
    public interface IMovableEntity : IEntity
    {
        Vector2d GetVector();

        void SetVector(Vector2d vector);

        void SetVectorY(double y);

        void SetVectorX(double x);

        void resetY();

        void resetX();

        void Update();

    }
}