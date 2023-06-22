
using DnA.GGame;
using DnA.Main.Game.Api;
using DnA.Main.Game.Impl;
using DNA.Model.Game.Level;

namespace DNA.GGame
{
    public class GameEngine : IGameEngine
    {
        private Display? display;
        private IGameState? game;
        private readonly Level levelConstruct;
        private bool running;
        private static readonly double RATEUPDATE = 1.0d / 60.0d;
        private static GameThread? gameThread;
        private static IMenuFactory? menuFactory;
        private readonly IInputControl angelInputControl = new InputControl();
        private readonly IInputControl devilInputControl = new InputControl();
        private readonly int level;

        public GameEngine(int lvl)
        {
            levelConstruct = new Level(lvl);
            levelConstruct.EntitiesList();
            level = lvl;
            running = false;

        }

        public static void SetGameThread(GameThread gameT)
        {
            gameThread = gameT;
            menuFactory = new MenuFactory();
        }

        public static GameThread GetGameThread()
        {
            return gameThread;
        }

        public double GetScore() => game.GetScore();

        public int GetLevel()
        {
            return level;
        }

        public void Run()
        {
            display = new Display(levelConstruct.GetCharacters(), menuFactory, angelInputControl, devilInputControl);
            game = new GameState(Display.GetScreenDimension(), Display.GetScreenDimension(),
                levelConstruct.GetEntities(), levelConstruct.GetCharacters());
            running = true;
            double accumulator = 0;
            long currentTime, lastUpdate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            while (running)
            {
                currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                double lastTimeInSeconds = (currentTime - lastUpdate) / 1000d;
                accumulator += lastTimeInSeconds;
                lastUpdate = currentTime;

                while (accumulator >= RATEUPDATE)
                {
                    if (running)
                    {
                        angelInputControl.ComputeAll();
                        devilInputControl.ComputeAll();
                        Update();
                    }
                    accumulator -= RATEUPDATE;
                }
                Render();
            }
        }

        private void Render()
        {
            display.Render(game.GetEntities(), game.GetCharacters());
        }

        private void Update()
        {
            game.Update();
        }

        public void Stop()
        {
            running = false;
            display.Dispose();
        }

        public IMenuFactory GetMenuFactory()
        {
            return menuFactory;
        }

        public bool IsRunning()
        {
            return running;
        }

    }
}
