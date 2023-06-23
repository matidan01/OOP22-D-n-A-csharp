using DnA.GGame;

namespace DNA.GGame
{
    public interface IGameEngine
    {
        double? GetScore();

        int GetLevel();

        void Run();

        void Stop();

        IMenuFactory? GetMenuFactory();

        bool IsRunning();
    }


}
