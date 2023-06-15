namespace DnA {
    public interface  IPlayer
    {
        const double JUMPVELOCITY = 5.6;
        const double STANDARDVELOCITY = 0.64;
        State GetState();
        State GetStateCopy();
        void SetStateX(State.StateEnum stateX);
        void SetStateY(State.StateEnum stateY);
        PlayerType GetPlayerType();
        enum PlayerType {
            DEVIL,
            ANGEL
        }
    }
}