using My.GameSystem.Charactor;
using My.GameSystem.Parameter;

namespace My.GameSystem.Event
{
    public interface IChipEvent
    {
        string HappenEvent(ICharactor c);
    }

    public class ExpUpEvent : IChipEvent
    {
        public string HappenEvent(ICharactor c)
        {
            IParameter exp = c.Status()["EXP"];
            exp.Add(3000);
            return DecorateStyle("[Event]", "color") + " Get 3000 Exp. You are lucky boy.";
        }

        private string DecorateStyle(string text, string tag)
        {
            return $"<{tag}=orange>{text}</{tag}>";
        }

        public override string ToString()
        {
            return "Exp Up Event. Lucky!";
        }
    }

    public class BattleEvent : IChipEvent
    {
        public string HappenEvent(ICharactor c)
        {
            return "";
        }
    }
}