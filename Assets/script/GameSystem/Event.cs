using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IEventSituation
    {
        EventStatus Status { get; }
        ICharactor Self { get; }
        ICharactor Target { get; }
    }

    public enum EventStatus
    {
        STANDBY,
        PROCESSING,
        BATTLE
    }

    public class EventSituation : IEventSituation
    {
        public EventStatus Status { get; set; }
        public ICharactor Self { get; set; }
        public ICharactor Target { get; set; }
    }

    public interface IEventable
    {
        IEvent Event { get; }
        void InvokeEvent();
    }

    public interface IEvent
    {
        string Invoke(IEventSituation e);
    }
    
    public class BattleEvent : IEvent
    {
        public virtual string Invoke(IEventSituation e) => "";
    }
}