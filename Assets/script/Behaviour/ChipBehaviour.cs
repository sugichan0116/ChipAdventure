using My.GameSystem.Charactor;
using My.GameSystem.Event;
using System.Collections.Generic;
using UnityEngine;

namespace My.Behaviour.Chip
{
    public class ChipBehaviour : MonoBehaviour
    {
        //ui
        [SerializeField]
        private MapManager manager;

        [SerializeField]
        private List<ChipBehaviour> nexts;
        private IChipEvent chipEvent;
        
        public bool IsNextChip(ChipBehaviour c)
        {
            foreach (var next in nexts)
            {
                if (c == next) return true;
            }

            return false;
        }

        public bool IsLeafChip()
        {
            return nexts?.Count == 0;
        }

        public void PushNextChip(ChipBehaviour c)
        {
            if (nexts == null) nexts = new List<ChipBehaviour>();
            nexts.Add(c);
        }

        public IEnumerable<Vector3> NextPositions()
        {
            foreach (var next in nexts)
            {
                yield return next.transform.position;
            }
        }

        public IChipEvent Event() => chipEvent;

        public void InvokeEvent(ICharactor c)
        {
            string outText = chipEvent.HappenEvent(c);
            PublishMessageLog(outText);
        }


        //ui
        public void SetManager(MapManager m) => manager = m;
        public void SetEvent(IChipEvent e) => chipEvent = e;
        
        public void PublishManager() => manager.ChipListener(this);

        public void PublishDetail() => manager.UpdateText(
            new UI.TextMessage() {
                key = "event",
                type = UI.MessageType.SET,
                text = ":event:\n" + ToString()
            }
        );

        public void PublishMessageLog(string text)
        {
            if (text == null) return;
            manager.UpdateText(
                 new UI.TextMessage()
                 {
                     key = "log",
                     type = UI.MessageType.ADD,
                     text = text + ":attack::exp:"
                 }
            );
            manager.UpdateText(
                  new UI.TextMessage()
                  {
                      key = "popup",
                      text = text,
                      locate = new Vector3(-200, 0)
                  }
             );
        }

        public override string ToString()
        {
            return chipEvent.ToString();
        }
        
        public string ToStringDebug()
        {
            string log = "";
            foreach (var next in nexts)
            {
                log += $"<{next.transform.position}>,";
            }
            return ToString() + log;
        }
    }
}
