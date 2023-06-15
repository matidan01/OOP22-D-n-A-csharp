namespace DnA {

    public class Player : IPlayer
    {
        private readonly IPlayer.PlayerType _playerType;
        private readonly State _playerState = new State();

        public Player(Position2d pos, Vector2d vet, double height, double width, PlayerType type)
            : base(pos, vet, height, width, Entity.EntityType.PLAYER)
        {
            _playerType = type;
        }

        public override void Update()
        {
            base.Update();
        }

        public State GetState()
        {
            return _playerState;
        }

        public State GetStateCopy()
        {
            return new State(_playerState._stateX, _playerState._stateY);
        }

        public IPlayer.PlayerType GetPlayerType()
        {
            return _playerType;
        }

        public void SetStateX(State.StateEnum stateX)
        {
            _playerState.SetState(stateX, _playerState._stateY);
        }

        public void SetStateY(State.StateEnum stateY)
        {
            _playerState.SetState(_playerState._stateX, stateY);
        }

    }

}