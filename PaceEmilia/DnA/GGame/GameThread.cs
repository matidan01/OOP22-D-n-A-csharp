namespace DNA.GGame
{
    /// <summary>
    /// The GameThread class represents a thread that manages the game execution.
    /// It interacts with the GameEngine to start, stop, and handle game events.
    /// </summary>
    public class GameThread
    {
        private IGameEngine gameEngine;
        private Thread? thread;
        private int lvl;

        /// <summary>
        /// Constructs a GameThread object with the specified GameEngine.
        /// </summary>
        /// <param name="gameEngine">The GameEngine instance to associate with the thread.</param>
        public GameThread(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
            GameEngine.SetGameThread(this);
        }

        /// <summary>
        /// Sets the GameEngine instance associated with the thread.
        /// </summary>
        /// <param name="gameEngine">The GameEngine instance to set.</param>
        public void SetGameEngine(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        /// <summary>
        /// Retrieves the GameEngine instance associated with the thread.
        /// </summary>
        /// <returns>The associated GameEngine instance.</returns>
        public IGameEngine GetGameEngine()
        {
            return gameEngine;
        }

        /// <summary>
        /// Starts the game thread.
        /// Creates a new thread and starts the execution of the game engine.
        /// </summary>
        public void Start()
        {
            thread = new Thread(gameEngine.Run);
            thread.Start();
        }

        /// <summary>
        /// Handles the victory event in the game.
        /// If the current level is the last level, it creates the last victory menu.
        /// Otherwise, it increments the level, creates the victory menu for the next level,
        /// interrupts the previous thread, and stops the previous game engine.
        /// </summary>
        public void VictoryGame()
        {
            lvl = gameEngine.GetLevel();
            if (lvl == 3)
            {
                this.gameEngine.GetMenuFactory().LastVictoryMenu().CreateMenuForm();
            }
            else
            {
                lvl++;
                this.gameEngine.GetMenuFactory().VictoryMenu(lvl).CreateMenuForm();
            }

            thread.Interrupt();
            gameEngine.Stop();
        }

        /// <summary>
        /// Handles the game loss event.
        /// It creates the game over menu for the current level,
        /// interrupts the previous thread, and stops the previous game engine.
        /// </summary>
        public void LoosingGame()
        {
            lvl = gameEngine.GetLevel();
            gameEngine.GetMenuFactory().GameOverMenu(lvl).CreateMenuForm();
            thread.Interrupt();
            gameEngine.Stop();
        }

        /// <summary>
        /// Interrupts the game thread and stops the associated game engine if it is running.
        /// </summary>
        public void InterruptGame()
        {
            thread.Interrupt();
            if (gameEngine.IsRunning())
            {
                gameEngine.Stop();
            }
        }
    }
}
