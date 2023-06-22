using DNA.GGame;

namespace DnA.GGame
{
    public class MenuFactory : IMenuFactory
    {
        private readonly GameThread gameThread;

        public MenuFactory(GameThread gameThread)
        {
            this.gameThread = gameThread;
        }

        public IGameMenu GameOverMenu(int levelNumber)
        {
            throw new NotImplementedException();
        }

        public IGameMenu LastVictoryMenu()
        {
            throw new NotImplementedException();
        }

        public IGameMenu PauseMenu()
        {
            throw new NotImplementedException();
        }

        public IGameMenu StartMenu()
        {
            throw new NotImplementedException();
        }

        public IGameMenu VictoryMenu(int lvl)
        {
            throw new NotImplementedException();
        }
    }
}