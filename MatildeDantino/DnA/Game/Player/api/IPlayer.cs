using DnA.Game.MovableEntity.Api;
using DnA.Game.Player.impl;

namespace DnA.Game.Player.api {

    ///
    /// An interface representing the Game Character.
    ///
    public interface  IPlayer : IMovableEntity
    {
        ///
        /// The jump speed value.
        ///
        const double JUMPVELOCITY = 5.6;

        ///
        /// The standard velocity of the Player.
        ///
        const double STANDARDVELOCITY = 0.64;

        ///
        /// Returns the current state of the player.
        ///
        /// <returns>The current state of the player.</returns>
        State GetState();

        ///
        /// Returns a copy of the current player's state.
        ///
        /// <returns>A copy of the current player's state.</returns>
        State GetStateCopy();

        ///
        /// Sets the first state of the player.
        ///
        /// <param name="stateX">The first state to set.</param>
        ///
        void SetStateX(State.StateEnum stateX);

        ///
        /// Sets the second state of the player.
        ///
        /// <param name="stateY">The second state to set.</param>
        ///
        void SetStateY(State.StateEnum stateY);

        ///
        /// Returns the type of the player.
        ///
        /// <returns>The player's type.</returns>
        PlayerType GetPlayerType();

        ///
        /// An enum representing the type of the Player.
        ///
        enum PlayerType {
            ///
            /// Represents when the player is a devil.
            ///
            DEVIL,

            ///
            /// Represents when the player is an angel.
            ///
            ANGEL
        }
    }
}