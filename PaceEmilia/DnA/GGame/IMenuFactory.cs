

namespace DnA.GGame
{
    public interface IMenuFactory 
    {
        IGameMenu StartMenu();
        IGameMenu GameOverMenu(int levelNumber);
        IGameMenu VictoryMenu(int lvl);
        IGameMenu LastVictoryMenu();
        IGameMenu PauseMenu();
    }


}
