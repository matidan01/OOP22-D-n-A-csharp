

using DnA.Game.enitity.Api;
/// <summery>
/// A class that allows some Entities to be activated.
/// </summary>

namespace DnA.Game.enitity.StillEntity.api{
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