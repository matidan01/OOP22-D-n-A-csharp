using DnA.Game.Player.impl;

namespace DnA.GGame
{
    public class Display
    {
        private List<Player> players;
        private IMenuFactory menuFactory;
        private IInputControl angelInputControl;
        private IInputControl devilInputControl;



        public void Display(List<Player> player, IMenuFactory menusFactory, IInputControl angelInputControls, IInputControl devilInputControls)
        {
            this.players = player;
            this.menuFactory = menusFactory;
            this.angelInputControl = angelInputControls;
            this.devilInputControl = devilInputControls;
        }
    }
 
}