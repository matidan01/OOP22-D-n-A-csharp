namespace DnA.Game.Command.api {

    /// <summary>
    /// Interface of a factory that creates <see cref="Command"/>s that can
    /// be given to the Player.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Returns a command that changes the vector of the Player to the right.
        /// </summary>
        /// <returns>A command that changes the vector of the Player to the right.</returns>
        ICommand Right();

        /// <summary>
        /// Returns a command that changes the vector of the Player to the left.
        /// </summary>
        /// <returns>A command that changes the vector of the Player to the left.</returns>
        ICommand Left();

        /// <summary>
        /// Returns a command that changes the vector of the Player upwards.
        /// </summary>
        /// <returns>A command that changes the vector of the Player upwards.</returns>
        ICommand Jump();

        /// <summary>
        /// Returns a command that resets the first coordinate of the Player's vector.
        /// </summary>
        /// <returns>A command that resets the first coordinate of the Player's vector.</returns>
        ICommand Stop();
    }
}
