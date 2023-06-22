using System;
using System.Windows.Forms;
namespace DnA.GGame
{
    public interface IGameMenu
    {
        Form CreateMenuForm();
    }

    public class GameMenu : IGameMenu
    {
        public Form CreateMenuForm()
        {
            Form menuFrame = new();
            return menuFrame;
        }
    }
}