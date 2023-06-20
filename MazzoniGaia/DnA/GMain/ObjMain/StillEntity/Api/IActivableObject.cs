using OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.Entity.Api;

namespace OOP22_D_n_A_csharp.MazzoniGaia.DnA.GMain.ObjMain.StillEntity.Api
{
    /// <summery>
    /// A class that allows some Entities to be activated.
    /// </summary>


    public interface IActivableObject : IEntity
    {
        /// <summary>
        /// Activates the GameObject.
        /// </summary>
        void Activate();

        /// <summary>
        /// 
        /// </summary>
        /// <returns> True if the GameObject is activated </returns>
        bool IsActivated();
    }
}