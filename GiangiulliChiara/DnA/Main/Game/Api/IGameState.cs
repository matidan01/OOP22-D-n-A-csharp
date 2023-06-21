using DnA.Game.Player.api;
using DnA.GMain.ObjMain.Entity.Api;
using DnA.Main.Box.Api;
namespace DnA.Main.Game.Api
{
    /// <summary>
    /// Interface that models the state of the game.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Updates the state of the game.
        /// </summary>
        void Update();

        /// <summary>
        /// Returns the <see cref="IBoundingBox"/>.
        /// </summary>
        /// <returns>The BoundingBox.</returns>
        IBoundingBox GetBoundingBox();

        /// <summary>
        /// Adds a new <see cref="Entity"/> to the game.
        /// </summary>
        /// <param name="e">The Entity to add.</param>
        void AddEntity(IEntity e);

        /// <summary>
        /// Removes an <see cref="Entity"/> from the game.
        /// </summary>
        /// <param name="e">The Entity to remove.</param>
        void RemoveEntity(IEntity e);

        /// <summary>
        /// Returns the list of <see cref="Entity"/> of the game.
        /// </summary>
        /// <returns>The list of entities.</returns>
        List<IEntity> GetEntities();

        /// <summary>
        /// Returns the list of characters of the game.
        /// </summary>
        /// <returns>The list of characters.</returns>
        List<IPlayer> GetCharacters();
        
        /// <summary>
        /// Returns the score of the game.
        /// </summary>
        /// <returns>The score value.</returns>
        double GetScore();
    }
}
