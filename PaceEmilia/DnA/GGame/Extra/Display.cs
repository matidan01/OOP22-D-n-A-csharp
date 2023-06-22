using DnA.Game.Player.api;
using DnA.Game.Player.impl;
using DnA.GMain.ObjMain.Entity.Api;

namespace DnA.GGame
{
    public class Display
    {
        private List<Player> ? players;
        private IMenuFactory ? menuFactory;
        private IInputControl angelInputControl;
        private IInputControl devilInputControl;
        private List<IPlayer> players1;

        public Display(List<IPlayer> players1, IMenuFactory? menuFactory, IInputControl angelInputControl, IInputControl devilInputControl)
        {
            this.players1 = players1;
            this.menuFactory = menuFactory;
            this.angelInputControl = angelInputControl;
            this.devilInputControl = devilInputControl;
        }


        internal static int GetScreenDimension()
        {
            return 1;
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void Render(List<IEntity> entities, List<IPlayer> players)
        {
            throw new NotImplementedException();
        }
    }
 
}