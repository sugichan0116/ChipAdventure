using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IEventSituation
    {
        ICharactor Player { get; }
        ICharactor Enemy { get; }
    }

    public class EventSituation : IEventSituation
    {
        public ICharactor Player { get; set; }
        public ICharactor Enemy { get; set; }
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