using DnA.Main.Game.Api;
namespace DnA.Main.Events.Api
{
    public class EventQueue
    {
        private Queue<IEvent> events;

        public EventQueue()
        {
            events = new Queue<IEvent>();
        }

        public void AddEvent(IEvent e)
        {
            events.Enqueue(e);
        }

        public void ClearQueue()
        {
            events.Clear();
        }

        public void ManageEvents(IGameState game)
        {
            while (events.Count > 0)
            {
                events.Dequeue().Manage(game);
            }
        }
    }

}