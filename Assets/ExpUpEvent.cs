using My.GameSystem.Charactor;
using My.GameSystem.Parameter;
using UnityEngine;

namespace My.GameSystem.Event
{
    public class ExpUpEvent : MonoBehaviour, IChipEvent
    {
        [SerializeField]
        private int expVolume = 3000;

        public string HappenEvent(ICharactor c)
        {
            IParameter exp = c.Status()["EXP"];
            exp.Add(expVolume);
            return DecorateStyle("[Event]", "color") + $" Get {expVolume} Exp. You are lucky boy.";
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
}