using My.GameSystem.Charactor;

namespace My.GameSystem.Event
{
    public interface IChipEvent
    {
        string HappenEvent(ICharactor c);
    }
    
    public class BattleEvent : IChipEvent
    {
        public string HappenEvent(ICharactor c)
        {
            return "";
        }
    }
}