using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IEventSituation
    {
        EventStatus Status { get; set; }
        ICharactor Self { get; }
        ICharactor Target { get; }
        void Invoke(IEvent e);
        string Log { get; set; }
    }

    public class EventSituation : IEventSituation
    {
        private IEvent nextEvent;
        public EventStatus Status { get; set; }
        public ICharactor Self { get; set; }
        public ICharactor Target { get; set; }
        public void Invoke(IEvent e)
        {
            nextEvent = e;
            e.Invoke(this);
        }
        public string Log { get; set; }
    }

    public enum EventStatus
    {
        STANDBY,
        PROCESSING,
        BATTLE
    }

    public interface IEventable
    {
        IEvent Event { get; }
        void InvokeEvent();
    }

    public interface IEvent
    {
        void Invoke(IEventSituation e);
    }
}