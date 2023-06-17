namespace DnA.Game.Command.api {

    /// <summary>
    /// A functional interface representing a generic command.
    /// </summary>
    public interface ICommand {

        /// <summary>
        /// Executes the Command.
        /// </summary>
        void Execute();
    }
}
