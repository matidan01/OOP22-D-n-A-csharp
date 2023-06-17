
namespace DnA {
///
/// A Class representing the state of a player.
///
public class State
{
    public StateEnum _stateX { get; private set; }
    public StateEnum _stateY { get; private set; }

    ///
    /// Constructs a new State object.
    /// The initial states are set to STATE_STANDING and STATE_STILL.
    ///
    public State()
    {
        _stateX = StateEnum.STATE_STANDING;
        _stateY = StateEnum.STATE_STILL;

    }

    ///
    /// Constructs a new State object with the specified X and Y states.
    ///
    /// <param name="stateX">The first state.</param>
    /// <param name="stateY">The second state.</param>
    ///
    public State(StateEnum stateX, StateEnum stateY)
    {
        _stateX = stateX;
        _stateY = stateY;

    }

    ///
    /// Sets the X and Y states of the player.
    ///
    /// <param name="stateX">The first state to set.</param>
    /// <param name="stateY">The second state to set.</param>
    ///
    public void SetState(StateEnum stateX, StateEnum stateY)
    {
        State oldState = new State(stateX, stateY);
        _stateX = stateX;
        _stateY = stateY;
    }

    ///
    /// Returns a Pair of states.
    ///
    /// <returns>A Pair of states.</returns>
    ///
    public Tuple<StateEnum, StateEnum> GetPairState() => Tuple.Create(_stateX, _stateY);


    ///
    /// An enumeration describing the different states of the player.
    ///
    public enum StateEnum
    {
        ///
        /// Represents when the player is on a platform.
        ///
        STATE_STANDING,

        ///
        /// Represents when the player is jumping.
        ///
        STATE_JUMPING,

        ///
        /// Represents when the player is moving right.
        ///
        STATE_RIGHT,

        ///
        /// Represents when the player is moving left.
        ///
        STATE_LEFT,

        ///
        /// Represents when the player is still.
        ///
        STATE_STILL
    }
}

}

