using DnA.Main.Game.Api;
namespace DnA.Main.Events.Api
{
    /// <summary>
    /// Functional interface for event management.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Manages the game state.
        /// </summary>
        /// <param name="game">The game state to manage.</param>
        public void Manage(IGameState game);
    }
}