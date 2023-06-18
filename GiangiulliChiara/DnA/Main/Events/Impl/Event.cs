using DnA.Main.Events.Api;
using DnA.Main.Game.Api;
namespace DnA.Main.Events.Impl
{
    public class Event : IEvent
    {
        private Action<IGameState> _manageAction;

        public Event(Action<IGameState> manageAction) => _manageAction = manageAction;

        public void Manage(IGameState game) => _manageAction(game);

    }

}