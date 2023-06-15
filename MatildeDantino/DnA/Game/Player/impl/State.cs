using System;
using System.Collections.Generic;
using System.ComponentModel;

public class State
{

    public StateEnum _stateX { get; private set; }
    public StateEnum _stateY { get; private set; }

    public State()
    {
        _stateX = StateEnum.STATE_STANDING;
        _stateY = StateEnum.STATE_STILL;

    }

    public State(StateEnum stateX, StateEnum stateY)
    {
        _stateX = stateX;
        _stateY = stateY;

    }

    public void SetState(StateEnum stateX, StateEnum stateY)
    {
        State oldState = new State(stateX, stateY);
        _stateX = stateX;
        _stateY = stateY;
    }

    public Tuple<StateEnum, StateEnum> GetPairState() => Tuple.Create(_stateX, _stateY);


    public enum StateEnum
    {
        STATE_STANDING,
        STATE_JUMPING,
        STATE_RIGHT,
        STATE_LEFT,
        STATE_STILL
    }
}
