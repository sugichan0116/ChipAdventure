using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IEventSituation
    {
        ICharactor Player { get; }
        ICharactor Enemy { get; }
    }


    public interface IChipEvent
    {
        string Invoke(IEventSituation e);
    }
    
    public class BattleEvent : IChipEvent
    {
        public virtual string Invoke(IEventSituation e) => "";
    }
}