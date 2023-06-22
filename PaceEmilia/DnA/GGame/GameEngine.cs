
using DnA.GGame;
using DnA.Main.Game.Api;
using DnA.Main.Game.Impl;
using DNA.Model.Game.Level;

namespace DNA.GGame
{
    public class GameEngine : IGameEngine
    {
        private Display ? display;
        private IGameState ? game;
        private readonly Level levelConstruct;
        private bool running;
        private static readonly double RATEUPDATE = 1.0d / 60.0d;
        private static GameThread ? gameThread;
        private static IMenuFactory ? menuFactory;
        private readonly IInputControl angelInputControl = new InputControl();
        private readonly IInputControl devilInputControl = new InputControl();
        private readonly int lvl;

        public GameEngine(int lvl)
        {
            this.levelConstruct = new Level(lvl);
            this.levelConstruct.EntitiesList();
            this.lvl = lvl;
            this.running = false;

        }

        public static void SetGameThread(GameThread gameT)
        {
            gameThread = gameT;
            menuFactory = new MenuFactoryImpl(gameThread);
        }

        public static GameThread GetGameThread()
        {
            return gameThread;
        }

        public double GetScore()
        {
            return this.game.GetScore();
        }

        public int GetLevel()
        {
            return this.lvl;
        }

        public void Run()
        {
            this.display = new Display(levelConstruct.GetCharacters(), menuFactory, angelInputControl, devilInputControl);
            this.game = new GameState(display.GetScreenDimension(), display.GetScreenDimension(),
                this.levelConstruct.GetEntities(), this.levelConstruct.GetCharacters());
            this.running = true;
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
                        this.angelInputControl.ComputeAll();
                        this.devilInputControl.ComputeAll();
                        this.Update();
                    }
                    accumulator -= RATEUPDATE;
                }
                this.Render();
            }
        }

        private void Render()
        {
            display.Render(this.game.GetEntities(), this.game.GetCharacters());
        }

        private void Update()
        {
            this.game.Update();
        }

        public void Stop()
        {
            this.running = false;
            this.display.Dispose();
        }

        public static void PlaySound(string audioFileName)
        {
            new SoundManager().GetClip(audioFileName).Start();
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
