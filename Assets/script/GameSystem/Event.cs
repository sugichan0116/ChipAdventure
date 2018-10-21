using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IEventSituation
    {
        EventStatus Status { get; set; }
        ICharactor Self { get; set; }
        ICharactor Target { get; set; }
        string Log { get; set; }
    }

    public class EventSituation : IEventSituation
    {
        public EventStatus Status { get; set; }
        public ICharactor Self { get; set; }
        public ICharactor Target { get; set; }
        public string Log { get; set; }
    }

    public enum EventStatus
    {
        STANDBY,
        PROCESSING,
        BATTLE_BEFORE,
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