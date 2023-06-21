using DnA.Main.Common;
using DnA.GMain.ObjMain.Entity.Api;

namespace DnA.GMain.ObjMain.MovableEntity.Api
{
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