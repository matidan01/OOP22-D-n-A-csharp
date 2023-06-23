using DnA.Game.Player.api;
using DnA.GMain.ObjMain.Entity.Api;

namespace DnA.GGame
{
    public class Display
    {


        public Display(List<IPlayer> players1, IMenuFactory? menuFactory1, IInputControl angelInputControl1, IInputControl devilInputControl)
        {
            Players = players1;
            MenusFactory = menuFactory1;
            AngelInputControl = angelInputControl1;
            DevilInputControl = devilInputControl;
        }

        public List<IPlayer> Players { get; }
        public IMenuFactory? MenusFactory { get; }
        public IInputControl AngelInputControl { get; }
        public IInputControl DevilInputControl { get; }

        internal static int GetScreenDimension()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Render(List<IEntity>? entities, List<IPlayer>? players)
        {
            throw new NotImplementedException();
        }
    }
 
}