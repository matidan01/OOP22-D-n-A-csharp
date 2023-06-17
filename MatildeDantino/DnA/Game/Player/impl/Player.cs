namespace DnA {

    /// <summary>
    /// IPlayer implementation.
    /// </summary>
    public class Player : AbstractEntity,IPlayer
    {
        private readonly IPlayer.PlayerType _playerType;
        private readonly State _playerState = new State();

        ///
        /// Constructs a new PlayerImpl object.
        ///
        /// <param name="pos">The position of the player.</param>
        /// <param name="vet">The vector of the player.</param>
        /// <param name="height">The height of the player.</param>
        /// <param name="width">The width of the player.</param>
        /// <param name="type">The type (angel/devil) of the player.</param>
        ///
        public Player(Position2d pos, Vector2d vet, double height, double width, IPlayer.PlayerType type)
            : base(pos, vet, height, width, Entity.EntityType.PLAYER)
        {
            _playerType = type;
        }

        /// <inheritdoc />
        public override void Update()
        {
            base.Update();
        }

        /// <inheritdoc />
        public State GetState()
        {
            return _playerState;
        }

        /// <inheritdoc />
        public State GetStateCopy()
        {
            return new State(_playerState._stateX, _playerState._stateY);
        }

        /// <inheritdoc />
        public IPlayer.PlayerType GetPlayerType()
        {
            return _playerType;
        }

        /// <inheritdoc />
        public void SetStateX(State.StateEnum stateX)
        {
            _playerState.SetState(stateX, _playerState._stateY);
        }

        /// <inheritdoc />
        public void SetStateY(State.StateEnum stateY)
        {
            _playerState.SetState(_playerState._stateX, stateY);
        }

    }

}